using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class LineRouteSection
    {
        [JsonProperty(PropertyName = "routeId")]
        public int? RouteId { get; set; }

        [JsonProperty(PropertyName = "direction")]
        public string Direction { get; set; }

        [JsonProperty(PropertyName = "destination")]
        public string Destination { get; set; }

        [JsonProperty(PropertyName = "fromStation")]
        public string FromStation { get; set; }

        [JsonProperty(PropertyName = "toStation")]
        public string ToStation { get; set; }

        [JsonProperty(PropertyName = "serviceType")]
        public string ServiceType { get; set; }

        [JsonProperty(PropertyName = "vehicleDestinationText")]
        public string VehicleDestinationText { get; set; }
    }
}