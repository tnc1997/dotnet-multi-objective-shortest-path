using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class Message
    {
        [JsonProperty(PropertyName = "bulletOrder")]
        public int? BulletOrder { get; set; }

        [JsonProperty(PropertyName = "header")]
        public bool? Header { get; set; }

        [JsonProperty(PropertyName = "messageText")]
        public string MessageText { get; set; }

        [JsonProperty(PropertyName = "linkText")]
        public string LinkText { get; set; }

        [JsonProperty(PropertyName = "url")] public string Url { get; set; }
    }
}