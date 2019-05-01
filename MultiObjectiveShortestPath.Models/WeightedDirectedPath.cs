using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public class WeightedDirectedPath<TVertex, TEdge> : PathBase<TVertex>, IWeightedDirectedPath<TVertex, TEdge>
    {
        public WeightedDirectedPath(
            IWeightedDirectedGraph<TVertex, TEdge> graph,
            TVertex origin
        ) : this(graph, origin, origin, new List<TVertex> {origin}, new List<TEdge>(), default)
        {
        }

        public WeightedDirectedPath(
            IWeightedDirectedGraph<TVertex, TEdge> graph,
            TVertex origin,
            TVertex destination,
            IEnumerable<TVertex> vertices,
            IEnumerable<TEdge> edges,
            TEdge weight
        ) : base(graph, origin, destination, vertices)
        {
            Graph = graph;
            Edges = edges;
            Weight = weight;
        }

        private IWeightedDirectedGraph<TVertex, TEdge> Graph { get; }

        public TEdge Weight { get; }

        public IEnumerable<TEdge> Edges { get; }
    }
}