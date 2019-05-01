using System;
using MultiObjectiveShortestPath.Apps.Console.Models;
using MultiObjectiveShortestPath.Models;

namespace MultiObjectiveShortestPath.Apps.Console.Adders
{
    public class EdgeAdder : Adder<Edge>
    {
        public override Edge Add(Edge x, Edge y)
        {
            if (x == null && y == null) throw new ArgumentNullException();

            if (x == null) return y;

            if (y == null) return x;

            return new Edge
            {
                Distance = x.Distance + y.Distance,
                Time = x.Time + y.Time,
                Comfortability = x.Comfortability + y.Comfortability,
                Reliability = x.Reliability + y.Reliability
            };
        }
    }
}