using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiObjectiveShortestPath.Models
{
    public class PathGeneticAlgorithm<TVertex, TEdge> : GeneticAlgorithmBase<TVertex, TEdge>
    {
        public PathGeneticAlgorithm(
            int noOfGenerations,
            int minPopulationSize,
            int maxPopulationSize,
            double mutationProbability,
            IWeightedDirectedGraph<TVertex, TEdge> graph,
            TVertex origin,
            TVertex destination
        ) : this(noOfGenerations, minPopulationSize, maxPopulationSize, mutationProbability, graph, origin, destination, Adder<TEdge>.Default, Comparer<TEdge>.Default)
        {
        }

        public PathGeneticAlgorithm(
            int noOfGenerations,
            int minPopulationSize,
            int maxPopulationSize,
            double mutationProbability,
            IWeightedDirectedGraph<TVertex, TEdge> graph,
            TVertex origin,
            TVertex destination,
            IAdder<TEdge> adder
        ) : this(noOfGenerations, minPopulationSize, maxPopulationSize, mutationProbability, graph, origin, destination, adder, Comparer<TEdge>.Default)
        {
        }

        public PathGeneticAlgorithm(
            int noOfGenerations,
            int minPopulationSize,
            int maxPopulationSize,
            double mutationProbability,
            IWeightedDirectedGraph<TVertex, TEdge> graph,
            TVertex origin,
            TVertex destination,
            IComparer<TEdge> comparer
        ) : this(noOfGenerations, minPopulationSize, maxPopulationSize, mutationProbability, graph, origin, destination, Adder<TEdge>.Default, comparer)
        {
        }

        public PathGeneticAlgorithm(
            int noOfGenerations,
            int minPopulationSize,
            int maxPopulationSize,
            double mutationProbability,
            IWeightedDirectedGraph<TVertex, TEdge> graph,
            TVertex origin,
            TVertex destination,
            IAdder<TEdge> adder,
            IComparer<TEdge> comparer
        ) : base(noOfGenerations, minPopulationSize, maxPopulationSize, mutationProbability)
        {
            Graph = graph;
            Origin = origin;
            Destination = destination;
            Adder = adder;
            Comparer = comparer;
        }
        
        private IWeightedDirectedGraph<TVertex, TEdge> Graph { get; }
        
        private TVertex Origin { get; }
        
        private TVertex Destination { get; }

        private IAdder<TEdge> Adder { get; }
        
        private IComparer<TEdge> Comparer { get; }

        protected override IChromosome<TVertex, TEdge> CreateChromosome()
        {
            var genes = CreatePath(Origin, Destination).ToList();
            
            return new PathChromosome<TVertex, TEdge>(genes, Adder, Comparer);
        }

        protected override void MutateChromosome(IChromosome<TVertex, TEdge> chromosome)
        {
            var random = new Random();

            var noOfUnmutatedGenes = 0;

            IEnumerable<IWeightedEndpoint<TVertex, TEdge>> mutatedGenes = null;

            while (mutatedGenes == null)
            {
                noOfUnmutatedGenes = random.Next(chromosome.Genes.Count);

                var unmutatedGenes = chromosome.Genes.Take(noOfUnmutatedGenes);

                var visited = new HashSet<TVertex>(unmutatedGenes.Select(endpoint => endpoint.Vertex));

                mutatedGenes = CreatePath(chromosome.Genes[noOfUnmutatedGenes], Destination, visited);
            }

            chromosome.Genes.RemoveRange(noOfUnmutatedGenes, chromosome.Genes.Count - noOfUnmutatedGenes);
            
            chromosome.Genes.AddRange(mutatedGenes);
        }

        private IEnumerable<IWeightedEndpoint<TVertex, TEdge>> CreatePath(
            TVertex origin,
            TVertex destination
        )
        {
            if (origin == null) throw new ArgumentNullException(nameof(origin));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

            return CreatePath(origin, destination, new HashSet<TVertex>());
        }

        private IEnumerable<IWeightedEndpoint<TVertex, TEdge>> CreatePath(
            IWeightedEndpoint<TVertex, TEdge> origin,
            TVertex destination
        )
        {
            if (origin == null) throw new ArgumentNullException(nameof(origin));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

            return CreatePath(origin, destination, new HashSet<TVertex>());
        }

        private IEnumerable<IWeightedEndpoint<TVertex, TEdge>> CreatePath(
            TVertex origin,
            TVertex destination,
            ICollection<TVertex> visited
        )
        {
            if (origin == null) throw new ArgumentNullException(nameof(origin));
            if (destination == null) throw new ArgumentNullException(nameof(destination));
            if (visited == null) throw new ArgumentNullException(nameof(visited));

            return CreatePath(new WeightedEndpoint<TVertex, TEdge>(origin, default), destination, visited);
        }

        private IEnumerable<IWeightedEndpoint<TVertex, TEdge>> CreatePath(
            IWeightedEndpoint<TVertex, TEdge> origin,
            TVertex destination,
            ICollection<TVertex> visited
        )
        {
            if (origin == null) throw new ArgumentNullException(nameof(origin));
            if (destination == null) throw new ArgumentNullException(nameof(destination));
            if (visited == null) throw new ArgumentNullException(nameof(visited));
            
            var random = new Random();
            
            visited.Add(origin.Vertex);

            var stack = new Stack<Tuple<IWeightedEndpoint<TVertex, TEdge>, IList<IWeightedEndpoint<TVertex, TEdge>>>>();
            
            stack.Push(new Tuple<IWeightedEndpoint<TVertex, TEdge>, IList<IWeightedEndpoint<TVertex, TEdge>>>(
                origin,
                Graph.SuccessorEndpoints(origin.Vertex).ToList()
            ));

            while (stack.Count > 0)
            {
                var (endpoint, successorEndpoints) = stack.Peek();

                if (Equals(endpoint.Vertex, destination)) return stack.Select(tuple => tuple.Item1).Reverse();

                if (successorEndpoints.Count == 0)
                {
                    stack.Pop();
                }
                else
                {
                    var index = random.Next(successorEndpoints.Count);

                    var successorEndpoint = successorEndpoints[index];

                    visited.Add(successorEndpoint.Vertex);

                    bool Predicate(IWeightedEndpoint<TVertex, TEdge> grandchildEndpoint)
                    {
                        return !visited.Contains(grandchildEndpoint.Vertex);
                    }

                    stack.Push(new Tuple<IWeightedEndpoint<TVertex, TEdge>, IList<IWeightedEndpoint<TVertex, TEdge>>>(
                        successorEndpoint,
                        Graph.SuccessorEndpoints(successorEndpoint.Vertex).Where(Predicate).ToList()
                    ));

                    successorEndpoints.RemoveAt(index);
                }
            }

            return null;
        }
    }
}