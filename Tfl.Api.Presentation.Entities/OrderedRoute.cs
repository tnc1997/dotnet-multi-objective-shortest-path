using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class OrderedRoute
    {
        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "naptanIds")]
        public List<string> NaptanIds { get; set; }

        [JsonProperty(PropertyName = "serviceType")]
        public string ServiceType { get; set; }
    }
}