using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.AccidentStats
{
    public class AccidentStatsOrderedSummary
    {
        [JsonProperty(PropertyName = "year")] public int? Year { get; set; }

        [JsonProperty(PropertyName = "borough")]
        public string Borough { get; set; }

        [JsonProperty(PropertyName = "accidents")]
        public int? Accidents { get; set; }
    }
}