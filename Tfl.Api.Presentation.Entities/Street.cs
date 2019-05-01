using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class Street
    {
        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "closure")]
        public string Closure { get; set; }

        [JsonProperty(PropertyName = "directions")]
        public string Directions { get; set; }

        [JsonProperty(PropertyName = "segments")]
        public List<StreetSegment> Segments { get; set; }

        [JsonProperty(PropertyName = "sourceSystemId")]
        public long? SourceSystemId { get; set; }

        [JsonProperty(PropertyName = "sourceSystemKey")]
        public string SourceSystemKey { get; set; }
    }
}