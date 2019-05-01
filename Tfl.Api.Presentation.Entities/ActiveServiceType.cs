using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class ActiveServiceType
    {
        [JsonProperty(PropertyName = "mode")] public string Mode { get; set; }

        [JsonProperty(PropertyName = "serviceType")]
        public string ServiceType { get; set; }
    }
}