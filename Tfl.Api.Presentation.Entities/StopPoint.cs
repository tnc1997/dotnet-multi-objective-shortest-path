using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class StopPoint : IEquatable<StopPoint>
    {
        [JsonProperty(PropertyName = "naptanId")]
        public string NaptanId { get; set; }

        [JsonProperty(PropertyName = "platformName")]
        public string PlatformName { get; set; }

        [JsonProperty(PropertyName = "indicator")]
        public string Indicator { get; set; }

        [JsonProperty(PropertyName = "stopLetter")]
        public string StopLetter { get; set; }

        [JsonProperty(PropertyName = "modes")] public List<string> Modes { get; set; }

        [JsonProperty(PropertyName = "icsCode")]
        public string IcsCode { get; set; }

        [JsonProperty(PropertyName = "smsCode")]
        public string SmsCode { get; set; }

        [JsonProperty(PropertyName = "stopType")]
        public string StopType { get; set; }

        [JsonProperty(PropertyName = "stationNaptan")]
        public string StationNaptan { get; set; }

        [JsonProperty(PropertyName = "accessibilitySummary")]
        public string AccessibilitySummary { get; set; }

        [JsonProperty(PropertyName = "hubNaptanCode")]
        public string HubNaptanCode { get; set; }

        [JsonProperty(PropertyName = "lines")] public List<Identifier> Lines { get; set; }

        [JsonProperty(PropertyName = "lineGroup")]
        public List<LineGroup> LineGroup { get; set; }

        [JsonProperty(PropertyName = "lineModeGroups")]
        public List<LineModeGroup> LineModeGroups { get; set; }

        [JsonProperty(PropertyName = "fullName")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "naptanMode")]
        public string NaptanMode { get; set; }

        [JsonProperty(PropertyName = "status")]
        public bool? Status { get; set; }

        [JsonProperty(PropertyName = "id")] public string Id { get; set; }

        [JsonProperty(PropertyName = "url")] public string Url { get; set; }

        [JsonProperty(PropertyName = "commonName")]
        public string CommonName { get; set; }

        [JsonProperty(PropertyName = "distance")]
        public double? Distance { get; set; }

        [JsonProperty(PropertyName = "placeType")]
        public string PlaceType { get; set; }

        [JsonProperty(PropertyName = "additionalProperties")]
        public List<AdditionalProperties> AdditionalProperties { get; set; }

        [JsonProperty(PropertyName = "children")]
        public List<Place> Children { get; set; }

        [JsonProperty(PropertyName = "childrenUrls")]
        public List<string> ChildrenUrls { get; set; }

        [JsonProperty(PropertyName = "lat")] public double? Lat { get; set; }

        [JsonProperty(PropertyName = "lon")] public double? Lon { get; set; }

        public bool Equals(StopPoint other)
        {
            if (ReferenceEquals(null, other)) return false;

            if (ReferenceEquals(this, other)) return true;

            return string.Equals(NaptanId, other.NaptanId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;

            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != GetType()) return false;

            return Equals((StopPoint) obj);
        }

        public override int GetHashCode()
        {
            return NaptanId != null ? NaptanId.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return CommonName;
        }
    }
}