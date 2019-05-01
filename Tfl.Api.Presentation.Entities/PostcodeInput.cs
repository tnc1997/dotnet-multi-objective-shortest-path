using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class PostcodeInput
    {
        [JsonProperty(PropertyName = "postcode")]
        public string Postcode { get; set; }
    }
}