using System.Collections;
using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public class DepthFirstSearchGraphEnumerator<TVertex> : IGraphEnumerator<TVertex>
    {
        public DepthFirstSearchGraphEnumerator(IDirectedGraph<TVertex> graph, TVertex origin)
        {
            Graph = graph;
            Origin = origin;
            Stack = new Stack<TVertex>();
            Visited = new HashSet<TVertex>();

            Initialize();
        }

        private IDirectedGraph<TVertex> Graph { get; }

        private TVertex Origin { get; }

        private Stack<TVertex> Stack { get; }

        private ICollection<TVertex> Visited { get; }

        public bool MoveNext()
        {
            while (Stack.Count > 0)
            {
                Current = Stack.Pop();

                if (Visited.Contains(Current)) continue;

                Visited.Add(Current);

                foreach (var vertex in Graph.SuccessorVertices(Current)) Stack.Push(vertex);

                return true;
            }

            return false;
        }

        public void Reset()
        {
            Stack.Clear();
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
            Stack.Push(Origin);
        }
    }
}