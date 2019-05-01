using System.Collections.Generic;
using MultiObjectiveShortestPath.Apps.Console.Models;
using static System.Console;

namespace MultiObjectiveShortestPath.Apps.Console.Comparers
{
    internal class EdgeComparer : Comparer<Edge>
    {
        public EdgeComparer() : this(true)
        {
        }

        public EdgeComparer(bool shouldSimulateInteractiveComparison)
        {
            ShouldSimulateInteractiveComparison = shouldSimulateInteractiveComparison;
        }

        public int NoOfTotalComparisons { get; set; }

        public int NoOfInteractiveComparisons { get; set; }

        private bool ShouldSimulateInteractiveComparison { get; }

        public override int Compare(Edge x, Edge y)
        {
            NoOfTotalComparisons++;

            if (x == null) return y == null ? 0 : -1;

            if (y == null) return 1;

            var timeComparison = x.Time.CompareTo(y.Time);
            var distanceComparison = x.Distance.CompareTo(y.Distance);
            var comfortabilityComparison = x.Comfortability.CompareTo(y.Comfortability);
            var reliabilityComparison = x.Reliability.CompareTo(y.Reliability);

            // Returns true if edge x is dominated by edge y; otherwise, false.
            bool IsDominated()
            {
                return timeComparison <= 0 &&
                       distanceComparison <= 0 &&
                       comfortabilityComparison >= 0 &&
                       reliabilityComparison >= 0;
            }

            if (IsDominated()) return -1;

            // Returns true if edge x dominates edge y; otherwise, false.
            bool IsDominator()
            {
                return timeComparison >= 0 &&
                       distanceComparison >= 0 &&
                       comfortabilityComparison <= 0 &&
                       reliabilityComparison <= 0;
            }

            if (IsDominator()) return 1;

            NoOfInteractiveComparisons++;

            if (ShouldSimulateInteractiveComparison) return x.Time.CompareTo(y.Time);

            WriteLine(
                $"[x] Time: {x.Time}, Distance: {x.Distance}, Comfortability: {x.Comfortability}, Reliability: {x.Reliability}"
            );
            WriteLine(
                $"[y] Time: {y.Time}, Distance: {y.Distance}, Comfortability: {y.Comfortability}, Reliability: {y.Reliability}"
            );

            Write("Compare (x < y = -1, x > y = 1): ");
            return Read();
        }
    }
}