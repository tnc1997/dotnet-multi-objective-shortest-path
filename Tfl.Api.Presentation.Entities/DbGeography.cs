using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class DbGeography
    {
        [JsonProperty(PropertyName = "geography")]
        public DbGeographyWellKnownValue Geography { get; set; }
    }
}