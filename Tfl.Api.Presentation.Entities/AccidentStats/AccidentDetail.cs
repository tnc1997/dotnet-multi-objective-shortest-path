using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.AccidentStats
{
    public class AccidentDetail
    {
        [JsonProperty(PropertyName = "id")] public int? Id { get; set; }

        [JsonProperty(PropertyName = "lat")] public double? Lat { get; set; }

        [JsonProperty(PropertyName = "lon")] public double? Lon { get; set; }

        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        [JsonProperty(PropertyName = "date")] public DateTimeOffset? Date { get; set; }

        [JsonProperty(PropertyName = "severity")]
        public string Severity { get; set; }

        [JsonProperty(PropertyName = "borough")]
        public string Borough { get; set; }

        [JsonProperty(PropertyName = "casualties")]
        public List<Casualty> Casualties { get; set; }

        [JsonProperty(PropertyName = "vehicles")]
        public List<Vehicle> Vehicles { get; set; }
    }
}