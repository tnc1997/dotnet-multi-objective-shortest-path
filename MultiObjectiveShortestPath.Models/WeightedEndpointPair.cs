using System;
using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public class WeightedEndpointPair<TVertex, TEdge> : IEquatable<WeightedEndpointPair<TVertex, TEdge>>,
        IWeightedEndpointPair<TVertex, TEdge>
    {
        public WeightedEndpointPair()
        {
        }

        public WeightedEndpointPair(TVertex origin, TVertex destination, TEdge edge)
        {
            Origin = origin;
            Destination = destination;
            Edge = edge;
        }

        public bool Equals(WeightedEndpointPair<TVertex, TEdge> other)
        {
            if (ReferenceEquals(null, other)) return false;

            if (ReferenceEquals(this, other)) return true;

            return EqualityComparer<TVertex>.Default.Equals(Destination, other.Destination) &&
                   EqualityComparer<TVertex>.Default.Equals(Origin, other.Origin) &&
                   EqualityComparer<TEdge>.Default.Equals(Edge, other.Edge);
        }

        public TVertex Origin { get; }

        public TVertex Destination { get; }

        public TEdge Edge { get; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;

            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != GetType()) return false;

            return Equals((WeightedEndpointPair<TVertex, TEdge>) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = EqualityComparer<TVertex>.Default.GetHashCode(Destination);
            hashCode = (hashCode * 397) ^ EqualityComparer<TVertex>.Default.GetHashCode(Origin);
            hashCode = (hashCode * 397) ^ EqualityComparer<TEdge>.Default.GetHashCode(Edge);
            return hashCode;
        }

        public override string ToString()
        {
            return $"{Origin}, {Destination}, {Edge}";
        }
    }
}