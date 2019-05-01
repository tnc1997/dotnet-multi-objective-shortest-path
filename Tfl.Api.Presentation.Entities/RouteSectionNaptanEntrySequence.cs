using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class RouteSectionNaptanEntrySequence
    {
        [JsonProperty(PropertyName = "ordinal")]
        public int? Ordinal { get; set; }

        [JsonProperty(PropertyName = "stopPoint")]
        public StopPoint StopPoint { get; set; }
    }
}