using System;
using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public class UnweightedEndpoint<TVertex> : IEquatable<UnweightedEndpoint<TVertex>>, IUnweightedEndpoint<TVertex>
    {
        public UnweightedEndpoint()
        {
        }

        public UnweightedEndpoint(TVertex vertex)
        {
            Vertex = vertex;
        }

        public bool Equals(UnweightedEndpoint<TVertex> other)
        {
            if (ReferenceEquals(null, other)) return false;

            if (ReferenceEquals(this, other)) return true;

            return EqualityComparer<TVertex>.Default.Equals(Vertex, other.Vertex);
        }

        public TVertex Vertex { get; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;

            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != GetType()) return false;

            return Equals((UnweightedEndpoint<TVertex>) obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<TVertex>.Default.GetHashCode(Vertex);
        }

        public override string ToString()
        {
            return Vertex.ToString();
        }
    }
}