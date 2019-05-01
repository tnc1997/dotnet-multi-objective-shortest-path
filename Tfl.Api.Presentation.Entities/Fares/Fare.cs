using System;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.Fares
{
    public class Fare
    {
        [JsonProperty(PropertyName = "id")] public int? Id { get; set; }

        [JsonProperty(PropertyName = "passengerType")]
        public string PassengerType { get; set; }

        [JsonProperty(PropertyName = "validFrom")]
        public DateTimeOffset? ValidFrom { get; set; }

        [JsonProperty(PropertyName = "validUntil")]
        public DateTimeOffset? ValidUntil { get; set; }

        [JsonProperty(PropertyName = "ticketTime")]
        public string TicketTime { get; set; }

        [JsonProperty(PropertyName = "ticketType")]
        public string TicketType { get; set; }

        [JsonProperty(PropertyName = "cost")] public string Cost { get; set; }

        [JsonProperty(PropertyName = "cap")] public double? Cap { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "zone")] public string Zone { get; set; }

        [JsonProperty(PropertyName = "mode")] public string Mode { get; set; }
    }
}