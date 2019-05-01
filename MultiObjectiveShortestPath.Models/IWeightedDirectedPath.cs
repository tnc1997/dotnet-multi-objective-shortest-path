using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public interface IWeightedDirectedPath<TVertex, TEdge> : IWeightedPath<TVertex, TEdge>, IDirectedPath<TVertex>
    {
        TEdge Weight { get; }

        IEnumerable<TEdge> Edges { get; }
    }
}