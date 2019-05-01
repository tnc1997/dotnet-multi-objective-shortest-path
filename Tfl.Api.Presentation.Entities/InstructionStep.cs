using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class InstructionStep
    {
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "turnDirection")]
        public string TurnDirection { get; set; }

        [JsonProperty(PropertyName = "streetName")]
        public string StreetName { get; set; }

        [JsonProperty(PropertyName = "distance")]
        public int? Distance { get; set; }

        [JsonProperty(PropertyName = "cumulativeDistance")]
        public int? CumulativeDistance { get; set; }

        [JsonProperty(PropertyName = "skyDirection")]
        public int? SkyDirection { get; set; }

        [JsonProperty(PropertyName = "skyDirectionDescription")]
        public string SkyDirectionDescription { get; set; }

        [JsonProperty(PropertyName = "cumulativeTravelTime")]
        public int? CumulativeTravelTime { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public double? Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public double? Longitude { get; set; }

        [JsonProperty(PropertyName = "pathAttribute")]
        public PathAttribute PathAttribute { get; set; }

        [JsonProperty(PropertyName = "descriptionHeading")]
        public string DescriptionHeading { get; set; }

        [JsonProperty(PropertyName = "trackType")]
        public string TrackType { get; set; }
    }
}