using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.Fares
{
    public class FareBounds
    {
        [JsonProperty(PropertyName = "id")] public int? Id { get; set; }

        [JsonProperty(PropertyName = "from")] public string FromProperty { get; set; }

        [JsonProperty(PropertyName = "to")] public string To { get; set; }

        [JsonProperty(PropertyName = "via")] public string Via { get; set; }

        [JsonProperty(PropertyName = "routeCode")]
        public string RouteCode { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "operator")]
        public string Operator { get; set; }

        [JsonProperty(PropertyName = "displayOrder")]
        public int? DisplayOrder { get; set; }

        [JsonProperty(PropertyName = "isPopularFare")]
        public bool? IsPopularFare { get; set; }

        [JsonProperty(PropertyName = "isPopularTravelCard")]
        public bool? IsPopularTravelCard { get; set; }

        [JsonProperty(PropertyName = "isTour")]
        public bool? IsTour { get; set; }

        [JsonProperty(PropertyName = "messages")]
        public List<Message> Messages { get; set; }
    }
}