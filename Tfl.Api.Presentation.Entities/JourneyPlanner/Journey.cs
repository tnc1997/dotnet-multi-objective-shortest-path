using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.JourneyPlanner
{
    public class Journey
    {
        [JsonProperty(PropertyName = "startDateTime")]
        public DateTimeOffset? StartDateTime { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public int? Duration { get; set; }

        [JsonProperty(PropertyName = "arrivalDateTime")]
        public DateTimeOffset? ArrivalDateTime { get; set; }

        [JsonProperty(PropertyName = "legs")] public List<Leg> Legs { get; set; }

        [JsonProperty(PropertyName = "fare")] public JourneyFare Fare { get; set; }
    }
}