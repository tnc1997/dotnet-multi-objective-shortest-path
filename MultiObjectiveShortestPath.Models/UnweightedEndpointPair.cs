using System;
using System.Collections.Generic;

namespace MultiObjectiveShortestPath.Models
{
    public class UnweightedEndpointPair<TVertex> : IEquatable<UnweightedEndpointPair<TVertex>>,
        IUnweightedEndpointPair<TVertex>
    {
        public UnweightedEndpointPair()
        {
        }

        public UnweightedEndpointPair(TVertex origin, TVertex destination)
        {
            Origin = origin;
            Destination = destination;
        }

        public bool Equals(UnweightedEndpointPair<TVertex> other)
        {
            if (ReferenceEquals(null, other)) return false;

            if (ReferenceEquals(this, other)) return true;

            return EqualityComparer<TVertex>.Default.Equals(Destination, other.Destination) &&
                   EqualityComparer<TVertex>.Default.Equals(Origin, other.Origin);
        }

        public TVertex Origin { get; }

        public TVertex Destination { get; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;

            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != GetType()) return false;

            return Equals((UnweightedEndpointPair<TVertex>) obj);
        }

        public override int GetHashCode()
        {
            return (EqualityComparer<TVertex>.Default.GetHashCode(Destination) * 397) ^
                   EqualityComparer<TVertex>.Default.GetHashCode(Origin);
        }

        public override string ToString()
        {
            return $"{Origin}, {Destination}";
        }
    }
}