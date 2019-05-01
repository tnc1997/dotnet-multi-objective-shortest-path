using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiObjectiveShortestPath.Models
{
    public class
        DijkstraShortestWeightedDirectedPathAlgorithm<TVertex, TEdge> : IShortestWeightedDirectedPathAlgorithm<TVertex,
            TEdge>
    {
        public DijkstraShortestWeightedDirectedPathAlgorithm(
            IWeightedDirectedGraph<TVertex, TEdge> graph
        ) : this(graph, Adder<TEdge>.Default, Comparer<TEdge>.Default)
        {
        }

        public DijkstraShortestWeightedDirectedPathAlgorithm(
            IWeightedDirectedGraph<TVertex, TEdge> graph,
            IAdder<TEdge> adder
        ) : this(graph, adder, Comparer<TEdge>.Default)
        {
        }

        public DijkstraShortestWeightedDirectedPathAlgorithm(
            IWeightedDirectedGraph<TVertex, TEdge> graph,
            IComparer<TEdge> comparer
        ) : this(graph, Adder<TEdge>.Default, comparer)
        {
        }

        public DijkstraShortestWeightedDirectedPathAlgorithm(
            IWeightedDirectedGraph<TVertex, TEdge> graph,
            IAdder<TEdge> adder,
            IComparer<TEdge> comparer
        )
        {
            Graph = graph;
            Adder = adder;
            Comparer = comparer;
        }

        private IWeightedDirectedGraph<TVertex, TEdge> Graph { get; }

        private IAdder<TEdge> Adder { get; }

        private IComparer<TEdge> Comparer { get; }

        public IWeightedDirectedPath<TVertex, TEdge> Path(TVertex origin, TVertex destination)
        {
            if (origin == null) throw new ArgumentNullException(nameof(origin));

            if (destination == null) throw new ArgumentNullException(nameof(destination));

            if (!Graph.Vertices.Contains(origin))
                throw new ArgumentException("The graph does not contain the specified origin.", nameof(origin));

            if (!Graph.Vertices.Contains(destination))
                throw new ArgumentException("The graph does not contain the specified destination.",
                    nameof(destination));

            if (Equals(origin, destination)) return new WeightedDirectedPath<TVertex, TEdge>(Graph, origin);

            var enumerator =
                new DijkstraShortestWeightedDirectedPathEnumerator<TVertex, TEdge>(Graph, origin, Adder,
                    Comparer);

            while (enumerator.MoveNext())
                if (Equals(enumerator.Current, destination))
                    break;

            return enumerator.PathCollection().Path(destination);
        }

        public IWeightedDirectedPathCollection<TVertex, TEdge> PathCollection(TVertex origin)
        {
            if (origin == null) throw new ArgumentNullException(nameof(origin));

            if (!Graph.Vertices.Contains(origin))
                throw new ArgumentException("The graph does not contain the specified origin.", nameof(origin));

            var enumerator =
                new DijkstraShortestWeightedDirectedPathEnumerator<TVertex, TEdge>(Graph, origin, Adder,
                    Comparer);

            while (enumerator.MoveNext())
            {
            }

            return enumerator.PathCollection();
        }
    }
}