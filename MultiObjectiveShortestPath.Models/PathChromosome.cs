using System.Collections.Generic;
using System.Linq;

namespace MultiObjectiveShortestPath.Models
{
    public class PathChromosome<TVertex, TEdge> : ChromosomeBase<TVertex, TEdge>
    {
        public PathChromosome(
            List<IWeightedEndpoint<TVertex, TEdge>> genes
        ) : this(genes, Adder<TEdge>.Default,  Comparer<TEdge>.Default)
        {
        }

        public PathChromosome(
            List<IWeightedEndpoint<TVertex, TEdge>> genes,
            IAdder<TEdge> adder
        ) : this(genes, adder,  Comparer<TEdge>.Default)
        {
        }

        public PathChromosome(
            List<IWeightedEndpoint<TVertex, TEdge>> genes,
            IComparer<TEdge> comparer
        ) : this(genes, Adder<TEdge>.Default,  comparer)
        {
        }

        public PathChromosome(
            List<IWeightedEndpoint<TVertex, TEdge>> genes,
            IAdder<TEdge> adder,
            IComparer<TEdge> comparer
        ) : base(genes, adder, comparer)
        {
        }

        public override IEnumerable<IChromosome<TVertex, TEdge>> Breed(IChromosome<TVertex, TEdge> other)
        {
            var children = new List<IChromosome<TVertex, TEdge>>();

            foreach (var crossoverGene in CrossoverGenes(other))
            {
                bool Predicate(IWeightedEndpoint<TVertex, TEdge> gene) => !Equals(gene, crossoverGene);

                var thisChild = Genes
                    .TakeWhile(Predicate)
                    .Concat(other.Genes.SkipWhile(Predicate))
                    .ToList();

                var otherChild = other.Genes
                    .TakeWhile(Predicate)
                    .Concat(Genes.SkipWhile(Predicate))
                    .ToList();

                children.Add(new PathChromosome<TVertex, TEdge>(thisChild, Adder, Comparer));
                children.Add(new PathChromosome<TVertex, TEdge>(otherChild, Adder, Comparer));
            }

            return children;
        }
    }
}