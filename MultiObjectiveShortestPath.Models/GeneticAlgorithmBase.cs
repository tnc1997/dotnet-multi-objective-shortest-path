using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MultiObjectiveShortestPath.Models
{
    public abstract class GeneticAlgorithmBase<TVertex, TEdge> : IGeneticAlgorithm<TVertex, TEdge>
    {
        protected GeneticAlgorithmBase(
            int noOfGenerations,
            int minPopulationSize,
            int maxPopulationSize,
            double mutationProbability
        )
        {
            NoOfGenerations = noOfGenerations;
            MinPopulationSize = minPopulationSize;
            MaxPopulationSize = maxPopulationSize;
            MutationProbability = mutationProbability;
            Parents = new LinkedList<IChromosome<TVertex, TEdge>>();
            Population = new LinkedList<IChromosome<TVertex, TEdge>>();
            Random = new Random();
            Stopwatch = new Stopwatch();
        }
        
        protected int NoOfGenerations { get; }

        protected int MinPopulationSize { get; }

        protected int MaxPopulationSize { get; }

        protected double MutationProbability { get; }

        protected LinkedList<IChromosome<TVertex, TEdge>> Parents { get; }

        protected LinkedList<IChromosome<TVertex, TEdge>> Population { get; }

        protected Random Random { get; }

        protected Stopwatch Stopwatch { get; }

        public IChromosome<TVertex, TEdge> FittestChromosome { get; private set; }

        public int Generation { get; private set; }

        public TimeSpan Time => Stopwatch.Elapsed;

        public event EventHandler GenerationEvolved;

        public void Evolve()
        {
            Stopwatch.Start();
            
            CreateFirstGeneration();

            while (Generation < NoOfGenerations)
            {
                foreach (var chromosome in Population)
                {
                    if (FittestChromosome == null || chromosome.CompareTo(FittestChromosome) < 0)
                    {
                        FittestChromosome = chromosome;
                    }
                }

                Select();

                Crossover();

                Mutate();

                Generation++;

                GenerationEvolved?.Invoke(this, EventArgs.Empty);
            }
            
            Stopwatch.Stop();
        }

        protected virtual void CreateFirstGeneration()
        {
            Population.Clear();

            var populationSize = Random.Next(MinPopulationSize, MaxPopulationSize);

            for (var i = 0; i < populationSize; i++)
            {
                var chromosome = CreateChromosome();

                Population.AddLast(chromosome);
            }
        }

        protected virtual void Select()
        {
            Parents.Clear();

            var competition = new List<IChromosome<TVertex, TEdge>>();

            while (Population.Count > 0)
            {
                competition.Clear();

                var competitionSize = Random.Next(2, 4);

                for (var i = 0; i < competitionSize && Population.Count > 0; i++)
                {
                    competition.Add(Population.First.Value);

                    Population.RemoveFirst();
                }
                
                competition.Sort();
                
                Parents.AddLast(competition.First());
            }
        }

        protected virtual void Crossover()
        {
            var nextGenerationSize = Random.Next(MinPopulationSize, MaxPopulationSize);
            
            var noOfRequiredChildren = nextGenerationSize - Parents.Count;
            
            while (noOfRequiredChildren > 0 && Parents.Count > 1)
            {
                var parent = Parents.ElementAt(Random.Next(Parents.Count));

                Parents.Remove(parent);
                Population.AddLast(parent);

                var mates = Parents.Where(chromosome => chromosome.CanBreed(parent)).ToList();

                if (mates.Count <= 0) continue;

                var partner = mates.ElementAt(Random.Next(mates.Count));

                Parents.Remove(partner);
                Population.AddLast(partner);

                var children = parent.Breed(partner).ToList();

                foreach (var child in children)
                {
                    Population.AddLast(child);

                    noOfRequiredChildren--;
                }
            }
            
            while (noOfRequiredChildren-- > 0)
            {
                var chromosome = CreateChromosome();

                Population.AddLast(chromosome);
            }
        }

        protected virtual void Mutate()
        {
            var noOfMutants = Math.Round(Population.Count * MutationProbability);

            for (var i = 0; i < noOfMutants; i++)
            {
                var index = Random.Next(Population.Count);
                var mutant = Population.ElementAt(index);

                MutateChromosome(mutant);
            }
        }

        protected abstract IChromosome<TVertex, TEdge> CreateChromosome();

        protected abstract void MutateChromosome(IChromosome<TVertex, TEdge> chromosome);
    }
}