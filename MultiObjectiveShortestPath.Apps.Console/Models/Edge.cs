using System;

namespace MultiObjectiveShortestPath.Apps.Console.Models
{
    public class Edge : IEquatable<Edge>
    {
        public string Line { get; set; }

        public string Direction { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public double Distance { get; set; }

        public TimeSpan Time { get; set; }

        public double Comfortability { get; set; }

        public double Reliability { get; set; }

        public bool Equals(Edge other)
        {
            if (ReferenceEquals(null, other)) return false;

            if (ReferenceEquals(this, other)) return true;

            return string.Equals(Line, other.Line) &&
                   string.Equals(Direction, other.Direction) &&
                   string.Equals(Origin, other.Origin) &&
                   string.Equals(Destination, other.Destination);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;

            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != GetType()) return false;

            return Equals((Edge) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = Line != null ? Line.GetHashCode() : 0;
            hashCode = (hashCode * 397) ^ (Direction != null ? Direction.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (Origin != null ? Origin.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (Destination != null ? Destination.GetHashCode() : 0);
            return hashCode;
        }

        public override string ToString()
        {
            return $"{Line}, {Direction}, {Origin}, {Destination}, {Time}, {Distance}, {Reliability}, {Comfortability}";
        }
    }
}