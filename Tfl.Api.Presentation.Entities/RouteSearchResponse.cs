using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class RouteSearchResponse
    {
        [JsonProperty(PropertyName = "input")] public string Input { get; set; }

        [JsonProperty(PropertyName = "searchMatches")]
        public List<RouteSearchMatch> SearchMatches { get; set; }
    }
}