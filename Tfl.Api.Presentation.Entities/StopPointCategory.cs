using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class StopPointCategory
    {
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "availableKeys")]
        public List<string> AvailableKeys { get; set; }
    }
}