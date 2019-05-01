using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.Fares
{
    public class FaresSection
    {
        [JsonProperty(PropertyName = "header")]
        public string Header { get; set; }

        [JsonProperty(PropertyName = "index")] public int? Index { get; set; }

        [JsonProperty(PropertyName = "rows")] public List<FareDetails> Rows { get; set; }

        [JsonProperty(PropertyName = "messages")]
        public List<Message> Messages { get; set; }
    }
}