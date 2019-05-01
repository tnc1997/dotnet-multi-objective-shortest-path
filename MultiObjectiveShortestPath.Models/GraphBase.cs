using System;
using System.Collections;
using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public abstract class GraphBase<TVertex, TVertexConnectionCollection> : IGraph<TVertex>
        where TVertexConnectionCollection : IVertexConnectionCollection<TVertex>, new()
    {
        protected GraphBase()
        {
            VertexConnectionCollections = new Dictionary<TVertex, TVertexConnectionCollection>();
        }

        protected IDictionary<TVertex, TVertexConnectionCollection> VertexConnectionCollections { get; }

        public IEnumerable<TVertex> Vertices => VertexConnectionCollections.Keys;

        public void AddVertex(TVertex vertex)
        {
            if (vertex == null) throw new ArgumentNullException(nameof(vertex));

            if (VertexConnectionCollections.ContainsKey(vertex)) throw new ArgumentException();

            VertexConnectionCollections.Add(vertex, new TVertexConnectionCollection());
        }

        public IEnumerable<TVertex> AdjacentVertices(TVertex vertex)
        {
            if (vertex == null) throw new ArgumentNullException(nameof(vertex));

            if (!VertexConnectionCollections.ContainsKey(vertex)) throw new ArgumentException();

            return VertexConnectionCollections[vertex].AdjacentVertices;
        }

        public int Degree(TVertex vertex)
        {
            if (vertex == null) throw new ArgumentNullException(nameof(vertex));

            if (!VertexConnectionCollections.ContainsKey(vertex)) throw new ArgumentException();

            return VertexConnectionCollections[vertex].Degree;
        }

        public IEnumerator<TVertex> GetEnumerator()
        {
            return Vertices.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}