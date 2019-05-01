using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.JourneyPlanner
{
    public class Leg
    {
        [JsonProperty(PropertyName = "duration")]
        public int? Duration { get; set; }

        [JsonProperty(PropertyName = "speed")] public string Speed { get; set; }

        [JsonProperty(PropertyName = "instruction")]
        public Instruction Instruction { get; set; }

        [JsonProperty(PropertyName = "obstacles")]
        public List<Obstacle> Obstacles { get; set; }

        [JsonProperty(PropertyName = "departureTime")]
        public DateTimeOffset? DepartureTime { get; set; }

        [JsonProperty(PropertyName = "arrivalTime")]
        public DateTimeOffset? ArrivalTime { get; set; }

        [JsonProperty(PropertyName = "departurePoint")]
        public Point DeparturePoint { get; set; }

        [JsonProperty(PropertyName = "arrivalPoint")]
        public Point ArrivalPoint { get; set; }

        [JsonProperty(PropertyName = "path")] public Path Path { get; set; }

        [JsonProperty(PropertyName = "routeOptions")]
        public List<RouteOption> RouteOptions { get; set; }

        [JsonProperty(PropertyName = "mode")] public Identifier Mode { get; set; }

        [JsonProperty(PropertyName = "disruptions")]
        public List<Disruption> Disruptions { get; set; }

        [JsonProperty(PropertyName = "plannedWorks")]
        public List<PlannedWork> PlannedWorks { get; set; }

        [JsonProperty(PropertyName = "distance")]
        public double? Distance { get; set; }

        [JsonProperty(PropertyName = "isDisrupted")]
        public bool? IsDisrupted { get; private set; }

        [JsonProperty(PropertyName = "hasFixedLocations")]
        public bool? HasFixedLocations { get; private set; }
    }
}