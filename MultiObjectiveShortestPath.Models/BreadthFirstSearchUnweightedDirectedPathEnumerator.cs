using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MultiObjectiveShortestPath.Models
{
    public class BreadthFirstSearchUnweightedDirectedPathEnumerator<TVertex> :
        IUnweightedDirectedPathEnumerator<TVertex>
    {
        public BreadthFirstSearchUnweightedDirectedPathEnumerator(
            IUnweightedDirectedGraph<TVertex> graph,
            TVertex origin
        )
        {
            Graph = graph;
            Origin = origin;
            Queue = new Queue<TVertex>();
            Visited = new Dictionary<TVertex, TVertex>();

            Initialize();
        }

        private IUnweightedDirectedGraph<TVertex> Graph { get; }

        private TVertex Origin { get; }

        private Queue<TVertex> Queue { get; }

        private IDictionary<TVertex, TVertex> Visited { get; }

        public IUnweightedDirectedPathCollection<TVertex> PathCollection()
        {
            return new UnweightedDirectedPathCollection<TVertex>(Graph, Origin, Visited);
        }

        public bool MoveNext()
        {
            if (Queue.Count == 0) return false;

            Current = Queue.Dequeue();

            bool Predicate(TVertex successorVertex)
            {
                return !Visited.ContainsKey(successorVertex);
            }

            foreach (var successorVertex in Graph.SuccessorVertices(Current).Where(Predicate))
            {
                Visited.Add(successorVertex, Current);
                Queue.Enqueue(successorVertex);
            }

            return true;
        }

        public void Reset()
        {
            Queue.Clear();
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
            Visited.Add(Origin, default);
            Queue.Enqueue(Origin);
        }
    }
}