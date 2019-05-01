using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class LineServiceType
    {
        [JsonProperty(PropertyName = "lineName")]
        public string LineName { get; set; }

        [JsonProperty(PropertyName = "lineSpecificServiceTypes")]
        public List<LineSpecificServiceType> LineSpecificServiceTypes { get; set; }
    }
}