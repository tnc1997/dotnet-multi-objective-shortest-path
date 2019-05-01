using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public class UnweightedDirectedPath<TVertex> : PathBase<TVertex>, IUnweightedDirectedPath<TVertex>
    {
        public UnweightedDirectedPath(
            IUnweightedDirectedGraph<TVertex> graph,
            TVertex origin
        ) : this(graph, origin, origin, new List<TVertex> {origin})
        {
        }

        public UnweightedDirectedPath(
            IUnweightedDirectedGraph<TVertex> graph,
            TVertex origin,
            TVertex destination,
            IEnumerable<TVertex> vertices
        ) : base(graph, origin, destination, vertices)
        {
            Graph = graph;
        }

        private IUnweightedDirectedGraph<TVertex> Graph { get; }
    }
}