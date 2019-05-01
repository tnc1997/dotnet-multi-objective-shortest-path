using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MultiObjectiveShortestPath.Models
{
    public class BreadthFirstSearchGraphEnumerator<TVertex> : IGraphEnumerator<TVertex>
    {
        public BreadthFirstSearchGraphEnumerator(IDirectedGraph<TVertex> graph, TVertex origin)
        {
            Graph = graph;
            Origin = origin;
            Queue = new Queue<TVertex>();
            Visited = new HashSet<TVertex>();

            Initialize();
        }

        private IDirectedGraph<TVertex> Graph { get; }

        private TVertex Origin { get; }

        private Queue<TVertex> Queue { get; }

        private ICollection<TVertex> Visited { get; }

        public bool MoveNext()
        {
            if (Queue.Count == 0) return false;

            Current = Queue.Dequeue();

            bool Predicate(TVertex successorVertex)
            {
                return !Visited.Contains(successorVertex);
            }

            foreach (var successorVertex in Graph.SuccessorVertices(Current).Where(Predicate))
            {
                Visited.Add(successorVertex);
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
            Visited.Add(Origin);
            Queue.Enqueue(Origin);
        }
    }
}