using System;
using System.Linq;

namespace MultiObjectiveShortestPath.Models
{
    public class DepthFirstSearchUnweightedDirectedPathAlgorithm<TVertex> : IUnweightedDirectedPathAlgorithm<TVertex>
    {
        public DepthFirstSearchUnweightedDirectedPathAlgorithm(IUnweightedDirectedGraph<TVertex> graph)
        {
            Graph = graph;
        }

        private IUnweightedDirectedGraph<TVertex> Graph { get; }

        public IUnweightedDirectedPath<TVertex> Path(TVertex origin, TVertex destination)
        {
            if (origin == null) throw new ArgumentNullException(nameof(origin));

            if (destination == null) throw new ArgumentNullException(nameof(destination));

            if (!Graph.Vertices.Contains(origin))
                throw new ArgumentException("The graph does not contain the specified origin.", nameof(origin));

            if (!Graph.Vertices.Contains(destination))
                throw new ArgumentException("The graph does not contain the specified destination.",
                    nameof(destination));

            var enumerator = new DepthFirstSearchUnweightedDirectedPathEnumerator<TVertex>(Graph, origin);

            while (enumerator.MoveNext())
                if (Equals(enumerator.Current, destination))
                    break;

            return enumerator.PathCollection().Path(destination);
        }

        public IUnweightedDirectedPathCollection<TVertex> PathCollection(TVertex origin)
        {
            if (origin == null) throw new ArgumentNullException(nameof(origin));

            if (!Graph.Vertices.Contains(origin))
                throw new ArgumentException("The graph does not contain the specified origin.", nameof(origin));

            var enumerator =
                new DepthFirstSearchUnweightedDirectedPathEnumerator<TVertex>(Graph, origin);

            while (enumerator.MoveNext())
            {
            }

            return enumerator.PathCollection();
        }
    }
}