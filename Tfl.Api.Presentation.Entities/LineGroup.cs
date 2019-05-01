using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class LineGroup
    {
        [JsonProperty(PropertyName = "naptanIdReference")]
        public string NaptanIdReference { get; set; }

        [JsonProperty(PropertyName = "stationAtcoCode")]
        public string StationAtcoCode { get; set; }

        [JsonProperty(PropertyName = "lineIdentifier")]
        public List<string> LineIdentifier { get; set; }
    }
}