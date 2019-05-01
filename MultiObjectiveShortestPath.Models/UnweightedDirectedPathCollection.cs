using System.Collections.Generic;
using System.Linq;

namespace MultiObjectiveShortestPath.Models
{
    public class UnweightedDirectedPathCollection<TVertex> : PathCollectionBase<TVertex>,
        IUnweightedDirectedPathCollection<TVertex>
    {
        public UnweightedDirectedPathCollection(
            IUnweightedDirectedGraph<TVertex> graph,
            TVertex origin,
            IDictionary<TVertex, TVertex> vertices
        ) : base(graph, origin)
        {
            Graph = graph;
            Vertices = vertices;
        }

        private IUnweightedDirectedGraph<TVertex> Graph { get; }

        private IDictionary<TVertex, TVertex> Vertices { get; }

        public override IEnumerator<IPath<TVertex>> GetEnumerator()
        {
            return Vertices.Keys.Select(Path).GetEnumerator();
        }

        public IUnweightedDirectedPath<TVertex> Path(TVertex destination)
        {
            if (Equals(Origin, destination)) return new UnweightedDirectedPath<TVertex>(Graph, Origin);

            if (!Vertices.ContainsKey(destination)) return null;

            var vertices = new LinkedList<TVertex>();

            var current = destination;

            while (Vertices.ContainsKey(current))
            {
                var predecessorVertex = Vertices[current];

                if (predecessorVertex == null) break;

                vertices.AddFirst(current);

                bool Predicate(TVertex vertex)
                {
                    return Equals(vertex, predecessorVertex);
                }

                current = Graph.PredecessorVertices(current).First(Predicate);
            }

            vertices.AddFirst(current);

            return new UnweightedDirectedPath<TVertex>(Graph, Origin, destination, vertices);
        }
    }
}