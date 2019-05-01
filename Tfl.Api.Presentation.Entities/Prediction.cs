using System;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class Prediction
    {
        [JsonProperty(PropertyName = "id")] public string Id { get; set; }

        [JsonProperty(PropertyName = "operationType")]
        public int? OperationType { get; set; }

        [JsonProperty(PropertyName = "vehicleId")]
        public string VehicleId { get; set; }

        [JsonProperty(PropertyName = "naptanId")]
        public string NaptanId { get; set; }

        [JsonProperty(PropertyName = "stationName")]
        public string StationName { get; set; }

        [JsonProperty(PropertyName = "lineId")]
        public string LineId { get; set; }

        [JsonProperty(PropertyName = "lineName")]
        public string LineName { get; set; }

        [JsonProperty(PropertyName = "platformName")]
        public string PlatformName { get; set; }

        [JsonProperty(PropertyName = "direction")]
        public string Direction { get; set; }

        [JsonProperty(PropertyName = "bearing")]
        public string Bearing { get; set; }

        [JsonProperty(PropertyName = "destinationNaptanId")]
        public string DestinationNaptanId { get; set; }

        [JsonProperty(PropertyName = "destinationName")]
        public string DestinationName { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public DateTimeOffset? Timestamp { get; set; }

        [JsonProperty(PropertyName = "timeToStation")]
        public int? TimeToStation { get; set; }

        [JsonProperty(PropertyName = "currentLocation")]
        public string CurrentLocation { get; set; }

        [JsonProperty(PropertyName = "towards")]
        public string Towards { get; set; }

        [JsonProperty(PropertyName = "expectedArrival")]
        public DateTimeOffset? ExpectedArrival { get; set; }

        [JsonProperty(PropertyName = "timeToLive")]
        public DateTimeOffset? TimeToLive { get; set; }

        [JsonProperty(PropertyName = "modeName")]
        public string ModeName { get; set; }

        [JsonProperty(PropertyName = "timing")]
        public PredictionTiming Timing { get; set; }
    }
}