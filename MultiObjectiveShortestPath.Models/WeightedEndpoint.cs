using System;
using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public class WeightedEndpoint<TVertex, TEdge> : IEquatable<WeightedEndpoint<TVertex, TEdge>>,
        IWeightedEndpoint<TVertex, TEdge>
    {
        public WeightedEndpoint()
        {
        }

        public WeightedEndpoint(TVertex vertex, TEdge edge)
        {
            Vertex = vertex;
            Edge = edge;
        }

        public bool Equals(WeightedEndpoint<TVertex, TEdge> other)
        {
            if (ReferenceEquals(null, other)) return false;

            if (ReferenceEquals(this, other)) return true;

            return EqualityComparer<TVertex>.Default.Equals(Vertex, other.Vertex) &&
                   EqualityComparer<TEdge>.Default.Equals(Edge, other.Edge);
        }

        public TVertex Vertex { get; }

        public TEdge Edge { get; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;

            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != GetType()) return false;

            return Equals((WeightedEndpoint<TVertex, TEdge>) obj);
        }

        public override int GetHashCode()
        {
            return (EqualityComparer<TVertex>.Default.GetHashCode(Vertex) * 397) ^
                   EqualityComparer<TEdge>.Default.GetHashCode(Edge);
        }

        public override string ToString()
        {
            return $"{Vertex}, {Edge}";
        }
    }
}