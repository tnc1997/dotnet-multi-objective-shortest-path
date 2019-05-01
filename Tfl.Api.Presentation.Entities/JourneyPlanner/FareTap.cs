using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.JourneyPlanner
{
    public class FareTap
    {
        [JsonProperty(PropertyName = "atcoCode")]
        public string AtcoCode { get; set; }

        [JsonProperty(PropertyName = "tapDetails")]
        public FareTapDetails TapDetails { get; set; }
    }
}