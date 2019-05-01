using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class MatchedRouteSections
    {
        [JsonProperty(PropertyName = "id")] public int? Id { get; set; }
    }
}