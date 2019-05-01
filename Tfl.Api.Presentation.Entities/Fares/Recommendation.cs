using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.Fares
{
    public class Recommendation
    {
        [JsonProperty(PropertyName = "id")] public int? Id { get; set; }

        [JsonProperty(PropertyName = "rule")] public int? Rule { get; set; }

        [JsonProperty(PropertyName = "rank")] public int? Rank { get; set; }

        [JsonProperty(PropertyName = "fareType")]
        public string FareType { get; set; }

        [JsonProperty(PropertyName = "product")]
        public string Product { get; set; }

        [JsonProperty(PropertyName = "ticketType")]
        public string TicketType { get; set; }

        [JsonProperty(PropertyName = "ticketTime")]
        public string TicketTime { get; set; }

        [JsonProperty(PropertyName = "productType")]
        public string ProductType { get; set; }

        [JsonProperty(PropertyName = "discountCard")]
        public string DiscountCard { get; set; }

        [JsonProperty(PropertyName = "zones")] public string Zones { get; set; }

        [JsonProperty(PropertyName = "cost")] public string Cost { get; set; }

        [JsonProperty(PropertyName = "priceDescription")]
        public string PriceDescription { get; set; }

        [JsonProperty(PropertyName = "priceComparison")]
        public string PriceComparison { get; set; }

        [JsonProperty(PropertyName = "recommendedTopUp")]
        public string RecommendedTopUp { get; set; }

        [JsonProperty(PropertyName = "notes")] public List<Message> Notes { get; set; }

        [JsonProperty(PropertyName = "keyFeatures")]
        public List<Message> KeyFeatures { get; set; }

        [JsonProperty(PropertyName = "gettingYourTicket")]
        public List<Message> GettingYourTicket { get; set; }

        [JsonProperty(PropertyName = "singleFare")]
        public double? SingleFare { get; set; }
    }
}