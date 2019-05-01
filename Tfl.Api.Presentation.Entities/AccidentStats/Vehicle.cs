using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.AccidentStats
{
    public class Vehicle
    {
        [JsonProperty(PropertyName = "type")] public string Type { get; set; }
    }
}