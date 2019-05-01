using System;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class DateRange
    {
        [JsonProperty(PropertyName = "startDate")]
        public DateTimeOffset? StartDate { get; set; }

        [JsonProperty(PropertyName = "endDate")]
        public DateTimeOffset? EndDate { get; set; }
    }
}