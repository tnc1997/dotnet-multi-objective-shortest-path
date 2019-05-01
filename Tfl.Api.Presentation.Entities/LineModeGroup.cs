using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class LineModeGroup
    {
        [JsonProperty(PropertyName = "modeName")]
        public string ModeName { get; set; }

        [JsonProperty(PropertyName = "lineIdentifier")]
        public List<string> LineIdentifier { get; set; }
    }
}