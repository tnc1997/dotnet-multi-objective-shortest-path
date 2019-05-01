using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class StopPointsResponse
    {
        [JsonProperty(PropertyName = "centrePoint")]
        public List<double?> CentrePoint { get; set; }

        [JsonProperty(PropertyName = "stopPoints")]
        public List<StopPoint> StopPoints { get; set; }

        [JsonProperty(PropertyName = "pageSize")]
        public int? PageSize { get; set; }

        [JsonProperty(PropertyName = "total")] public int? Total { get; set; }

        [JsonProperty(PropertyName = "page")] public int? Page { get; set; }
    }
}