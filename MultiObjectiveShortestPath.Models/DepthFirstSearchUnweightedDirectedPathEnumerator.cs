using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MultiObjectiveShortestPath.Models
{
    public class DepthFirstSearchUnweightedDirectedPathEnumerator<TVertex> :
        IUnweightedDirectedPathEnumerator<TVertex>
    {
        public DepthFirstSearchUnweightedDirectedPathEnumerator(
            IUnweightedDirectedGraph<TVertex> graph,
            TVertex origin
        )
        {
            Graph = graph;
            Origin = origin;
            Stack = new Stack<TVertex>();
            Visited = new Dictionary<TVertex, TVertex>();

            Initialize();
        }

        private IUnweightedDirectedGraph<TVertex> Graph { get; }

        private TVertex Origin { get; }

        private Stack<TVertex> Stack { get; }

        private IDictionary<TVertex, TVertex> Visited { get; }

        public IUnweightedDirectedPathCollection<TVertex> PathCollection()
        {
            return new UnweightedDirectedPathCollection<TVertex>(Graph, Origin, Visited);
        }

        public bool MoveNext()
        {
            while (Stack.Count > 0)
            {
                Current = Stack.Pop();

                bool Predicate(TVertex successorVertex)
                {
                    return !Visited.ContainsKey(successorVertex);
                }

                foreach (var successorVertex in Graph.SuccessorVertices(Current).Where(Predicate))
                {
                    Visited.Add(successorVertex, Current);
                    Stack.Push(successorVertex);
                }

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
            Visited.Add(Origin, default);
            Stack.Push(Origin);
        }
    }
}