using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class SearchResponse
    {
        [JsonProperty(PropertyName = "query")] public string Query { get; set; }

        [JsonProperty(PropertyName = "from")] public int? FromProperty { get; set; }

        [JsonProperty(PropertyName = "page")] public int? Page { get; set; }

        [JsonProperty(PropertyName = "pageSize")]
        public int? PageSize { get; set; }

        [JsonProperty(PropertyName = "provider")]
        public string Provider { get; set; }

        [JsonProperty(PropertyName = "total")] public int? Total { get; set; }

        [JsonProperty(PropertyName = "matches")]
        public List<SearchMatch> Matches { get; set; }

        [JsonProperty(PropertyName = "maxScore")]
        public double? MaxScore { get; set; }
    }
}