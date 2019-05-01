using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class LineSpecificServiceType
    {
        [JsonProperty(PropertyName = "serviceType")]
        public LineServiceTypeInfo ServiceType { get; set; }

        [JsonProperty(PropertyName = "stopServesServiceType")]
        public bool? StopServesServiceType { get; set; }
    }
}