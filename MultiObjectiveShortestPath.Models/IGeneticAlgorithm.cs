using System;

namespace MultiObjectiveShortestPath.Models
{
    public interface IGeneticAlgorithm<TVertex, TEdge> : IAlgorithm<TVertex>
    {
        IChromosome<TVertex, TEdge> FittestChromosome { get; }
        
        int Generation { get; }
        
        TimeSpan Time { get; }

        event EventHandler GenerationEvolved;

        void Evolve();
    }
}