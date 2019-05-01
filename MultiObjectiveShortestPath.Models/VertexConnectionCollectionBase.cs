using System.Collections;
using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public abstract class VertexConnectionCollectionBase<TVertex> : IVertexConnectionCollection<TVertex>
    {
        public abstract IEnumerable<TVertex> AdjacentVertices { get; }

        public abstract int Degree { get; }

        public IEnumerator<TVertex> GetEnumerator()
        {
            return AdjacentVertices.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}