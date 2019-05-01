using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.Fares
{
    public class Ticket
    {
        [JsonProperty(PropertyName = "passengerType")]
        public string PassengerType { get; set; }

        [JsonProperty(PropertyName = "ticketType")]
        public TicketType TicketType { get; set; }

        [JsonProperty(PropertyName = "ticketTime")]
        public TicketTime TicketTime { get; set; }

        [JsonProperty(PropertyName = "cost")] public string Cost { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "mode")] public string Mode { get; set; }

        [JsonProperty(PropertyName = "displayOrder")]
        public int? DisplayOrder { get; set; }

        [JsonProperty(PropertyName = "messages")]
        public List<Message> Messages { get; set; }
    }
}