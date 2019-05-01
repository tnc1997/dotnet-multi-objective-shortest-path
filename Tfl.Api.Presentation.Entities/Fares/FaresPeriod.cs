using System;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.Fares
{
    public class FaresPeriod
    {
        [JsonProperty(PropertyName = "id")] public int? Id { get; set; }

        [JsonProperty(PropertyName = "startDate")]
        public DateTimeOffset? StartDate { get; set; }

        [JsonProperty(PropertyName = "viewableDate")]
        public DateTimeOffset? ViewableDate { get; set; }

        [JsonProperty(PropertyName = "endDate")]
        public DateTimeOffset? EndDate { get; set; }

        [JsonProperty(PropertyName = "isFuture")]
        public bool? IsFuture { get; set; }
    }
}