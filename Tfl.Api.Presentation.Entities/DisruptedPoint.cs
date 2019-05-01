using System;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class DisruptedPoint
    {
        [JsonProperty(PropertyName = "atcoCode")]
        public string AtcoCode { get; set; }

        [JsonProperty(PropertyName = "fromDate")]
        public DateTimeOffset? FromDate { get; set; }

        [JsonProperty(PropertyName = "toDate")]
        public DateTimeOffset? ToDate { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "commonName")]
        public string CommonName { get; set; }

        [JsonProperty(PropertyName = "type")] public string Type { get; set; }

        [JsonProperty(PropertyName = "mode")] public string Mode { get; set; }

        [JsonProperty(PropertyName = "stationAtcoCode")]
        public string StationAtcoCode { get; set; }

        [JsonProperty(PropertyName = "appearance")]
        public string Appearance { get; set; }

        [JsonProperty(PropertyName = "additionalInformation")]
        public string AdditionalInformation { get; set; }
    }
}