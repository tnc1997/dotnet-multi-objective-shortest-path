using System.Collections;
using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public abstract class PathBase<TVertex> : IPath<TVertex>
    {
        protected PathBase(
            IGraph<TVertex> graph,
            TVertex origin
        ) : this(graph, origin, origin, new List<TVertex> {origin})
        {
        }

        protected PathBase(
            IGraph<TVertex> graph,
            TVertex origin,
            TVertex destination,
            IEnumerable<TVertex> vertices
        )
        {
            Graph = graph;
            Origin = origin;
            Destination = destination;
            Vertices = vertices;
        }

        private IGraph<TVertex> Graph { get; }

        public IEnumerator<TVertex> GetEnumerator()
        {
            return Vertices.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public TVertex Origin { get; }

        public TVertex Destination { get; }

        public IEnumerable<TVertex> Vertices { get; }
    }
}