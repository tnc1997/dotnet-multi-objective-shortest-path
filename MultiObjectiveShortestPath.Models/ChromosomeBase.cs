using System.Collections.Generic;
using System.Linq;

namespace MultiObjectiveShortestPath.Models
{
    public abstract class ChromosomeBase<TVertex, TEdge> : IChromosome<TVertex, TEdge>
    {
        protected ChromosomeBase(List<IWeightedEndpoint<TVertex, TEdge>> genes) : this(genes, Adder<TEdge>.Default, Comparer<TEdge>.Default)
        {
        }

        protected ChromosomeBase(List<IWeightedEndpoint<TVertex, TEdge>> genes, IAdder<TEdge> adder) : this(genes, adder, Comparer<TEdge>.Default)
        {
        }

        protected ChromosomeBase(List<IWeightedEndpoint<TVertex, TEdge>> genes, IComparer<TEdge> comparer) : this(genes, Adder<TEdge>.Default, comparer)
        {
        }

        protected ChromosomeBase(List<IWeightedEndpoint<TVertex, TEdge>> genes, IAdder<TEdge> adder, IComparer<TEdge> comparer)
        {
            Adder = adder;
            Comparer = comparer;
            Genes = genes;
        }
        
        protected IAdder<TEdge> Adder { get; }
        
        protected IComparer<TEdge> Comparer { get; }
        
        public List<IWeightedEndpoint<TVertex, TEdge>> Genes { get; }

        public TEdge Weight => Genes.Select(gene => gene.Edge).Aggregate((sum, edge) => Adder.Add(sum, edge));

        public abstract IEnumerable<IChromosome<TVertex, TEdge>> Breed(IChromosome<TVertex, TEdge> other);

        public bool CanBreed(IChromosome<TVertex, TEdge> other)
        {
            return !Equals(this, other) && CrossoverGenes(other).Any();
        }

        public IEnumerable<IWeightedEndpoint<TVertex, TEdge>> CrossoverGenes(IChromosome<TVertex, TEdge> other)
        {
            return Genes.GetRange(1, Genes.Count - 2).Intersect(other.Genes);
        }

        public int CompareTo(IChromosome<TVertex, TEdge> other)
        {
            return Comparer.Compare(Weight, other.Weight);
        }

        public bool Equals(IChromosome<TVertex, TEdge> other)
        {
            if (ReferenceEquals(null, other)) return false;
            
            if (ReferenceEquals(this, other)) return true;
            
            return Genes.SequenceEqual(other.Genes) && EqualityComparer<TEdge>.Default.Equals(Weight, other.Weight);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            
            if (ReferenceEquals(this, obj)) return true;
            
            if (obj.GetType() != GetType()) return false;
            
            return Equals((ChromosomeBase<TVertex, TEdge>) obj);
        }

        public override int GetHashCode()
        {
            return (Genes.GetHashCode() * 397) ^ EqualityComparer<TEdge>.Default.GetHashCode(Weight);
        }
    }
}