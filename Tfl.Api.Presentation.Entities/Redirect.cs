using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class Redirect
    {
        [JsonProperty(PropertyName = "shortUrl")]
        public string ShortUrl { get; set; }

        [JsonProperty(PropertyName = "longUrl")]
        public string LongUrl { get; set; }

        [JsonProperty(PropertyName = "active")]
        public bool? Active { get; set; }
    }
}