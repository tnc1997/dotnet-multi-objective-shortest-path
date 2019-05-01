using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.Fares
{
    public class FareDetails
    {
        [JsonProperty(PropertyName = "boundsId")]
        public int? BoundsId { get; set; }

        [JsonProperty(PropertyName = "startDate")]
        public DateTimeOffset? StartDate { get; set; }

        [JsonProperty(PropertyName = "endDate")]
        public DateTimeOffset? EndDate { get; set; }

        [JsonProperty(PropertyName = "mode")] public string Mode { get; set; }

        [JsonProperty(PropertyName = "passengerType")]
        public string PassengerType { get; set; }

        [JsonProperty(PropertyName = "from")] public string From { get; set; }

        [JsonProperty(PropertyName = "to")] public string To { get; set; }

        [JsonProperty(PropertyName = "fromStation")]
        public string FromStation { get; set; }

        [JsonProperty(PropertyName = "toStation")]
        public string ToStation { get; set; }

        [JsonProperty(PropertyName = "via")] public string Via { get; set; }

        [JsonProperty(PropertyName = "routeCode")]
        public string RouteCode { get; set; }

        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "displayOrder")]
        public int? DisplayOrder { get; set; }

        [JsonProperty(PropertyName = "routeDescription")]
        public string RouteDescription { get; set; }

        [JsonProperty(PropertyName = "validatorInformation")]
        public string ValidatorInformation { get; set; }

        [JsonProperty(PropertyName = "operator")]
        public string Operator { get; set; }

        [JsonProperty(PropertyName = "specialFare")]
        public bool? SpecialFare { get; set; }

        [JsonProperty(PropertyName = "throughFare")]
        public bool? ThroughFare { get; set; }

        [JsonProperty(PropertyName = "isTour")]
        public bool? IsTour { get; set; }

        [JsonProperty(PropertyName = "ticketsAvailable")]
        public List<Ticket> TicketsAvailable { get; set; }

        [JsonProperty(PropertyName = "messages")]
        public List<Message> Messages { get; set; }
    }
}