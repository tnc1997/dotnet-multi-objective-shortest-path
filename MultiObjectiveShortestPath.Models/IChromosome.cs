using System;
using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public interface IChromosome<TVertex, TEdge> : IComparable<IChromosome<TVertex, TEdge>>,
        IEquatable<IChromosome<TVertex, TEdge>>
    {
        List<IWeightedEndpoint<TVertex, TEdge>> Genes { get; }
        
        TEdge Weight { get; }

        IEnumerable<IChromosome<TVertex, TEdge>> Breed(IChromosome<TVertex, TEdge> other);

        bool CanBreed(IChromosome<TVertex, TEdge> other);

        IEnumerable<IWeightedEndpoint<TVertex, TEdge>> CrossoverGenes(IChromosome<TVertex, TEdge> other);
    }
}