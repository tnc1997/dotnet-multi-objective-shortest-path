using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.JourneyPlanner
{
    public class Path
    {
        [JsonProperty(PropertyName = "lineString")]
        public string LineString { get; set; }

        [JsonProperty(PropertyName = "stopPoints")]
        public List<Identifier> StopPoints { get; set; }

        [JsonProperty(PropertyName = "elevation")]
        public List<Elevation> Elevation { get; set; }
    }
}