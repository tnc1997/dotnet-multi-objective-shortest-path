using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MultiObjectiveShortestPath.Models
{
    public class DijkstraShortestWeightedDirectedPathEnumerator<TVertex, TEdge> :
        IShortestWeightedDirectedPathEnumerator<TVertex, TEdge>
    {
        public DijkstraShortestWeightedDirectedPathEnumerator(
            IWeightedDirectedGraph<TVertex, TEdge> graph,
            TVertex origin
        ) : this(graph, origin, Adder<TEdge>.Default, Comparer<TEdge>.Default)
        {
        }

        public DijkstraShortestWeightedDirectedPathEnumerator(
            IWeightedDirectedGraph<TVertex, TEdge> graph,
            TVertex origin,
            IAdder<TEdge> adder
        ) : this(graph, origin, adder, Comparer<TEdge>.Default)
        {
        }

        public DijkstraShortestWeightedDirectedPathEnumerator(
            IWeightedDirectedGraph<TVertex, TEdge> graph,
            TVertex origin,
            IComparer<TEdge> comparer
        ) : this(graph, origin, Adder<TEdge>.Default, comparer)
        {
        }

        public DijkstraShortestWeightedDirectedPathEnumerator(
            IWeightedDirectedGraph<TVertex, TEdge> graph,
            TVertex origin,
            IAdder<TEdge> adder,
            IComparer<TEdge> comparer
        )
        {
            Graph = graph;
            Origin = origin;
            Adder = adder;
            Comparer = comparer;
            Heap = new FibonacciHeap<TEdge, HeapEntry>(comparer);
            Visited = new Dictionary<TVertex, IMinHeapVertex<TEdge, HeapEntry>>();

            Initialize();
        }

        private IWeightedDirectedGraph<TVertex, TEdge> Graph { get; }

        private TVertex Origin { get; }

        private IAdder<TEdge> Adder { get; }

        private IComparer<TEdge> Comparer { get; }

        private IMinHeap<TEdge, HeapEntry> Heap { get; }

        private IDictionary<TVertex, IMinHeapVertex<TEdge, HeapEntry>> Visited { get; }

        public IWeightedDirectedPathCollection<TVertex, TEdge> PathCollection()
        {
            var edges = Visited.Values.ToDictionary(
                heapVertex => heapVertex.Value.Vertex,
                heapVertex => new Tuple<TEdge, TEdge>(heapVertex.Key, heapVertex.Value.Edge)
            );

            return new WeightedDirectedDirectedPathCollection<TVertex, TEdge>(Graph, Origin, edges, Adder);
        }

        public bool MoveNext()
        {
            if (Heap.IsEmpty) return false;

            var min = Heap.ExtractMin();

            Current = min.Value.Vertex;

            foreach (var endpoint in Graph.SuccessorEndpoints(Current))
            {
                var destination = endpoint.Vertex;
                var edge = endpoint.Edge;

                if (Comparer.Compare(edge, default) < 0)
                    throw new InvalidOperationException("This path enumerator does not allow negative edge weights.");

                UpdateWeight(destination, edge, Adder.Add(min.Key, edge));
            }

            return true;
        }

        public void Reset()
        {
            Heap.Clear();
            Visited.Clear();

            Current = default;

            Initialize();
        }

        public TVertex Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        private void Initialize()
        {
            UpdateWeight(Origin, default, default);
        }

        private void UpdateWeight(TVertex vertex, TEdge edge, TEdge weight)
        {
            if (!Visited.ContainsKey(vertex))
            {
                var heapVertex = Heap.Insert(weight, new HeapEntry(vertex, edge));

                Visited.Add(vertex, heapVertex);
            }
            else
            {
                var heapVertex = Visited[vertex];

                if (Comparer.Compare(weight, heapVertex.Key) >= 0) return;

                heapVertex.DecreaseKey(weight);
                heapVertex.Value.Edge = edge;
            }
        }

        private class HeapEntry
        {
            public HeapEntry(TVertex vertex, TEdge edge)
            {
                Vertex = vertex;
                Edge = edge;
            }

            public TVertex Vertex { get; }

            public TEdge Edge { get; set; }
        }
    }
}