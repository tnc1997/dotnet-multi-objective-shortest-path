using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.Fares
{
    public class RecommendationResponse
    {
        [JsonProperty(PropertyName = "recommendations")]
        public List<Recommendation> Recommendations { get; set; }
    }
}