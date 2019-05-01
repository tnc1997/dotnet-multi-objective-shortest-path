using System;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.JourneyPlanner
{
    public class SearchCriteria
    {
        [JsonProperty(PropertyName = "dateTime")]
        public DateTimeOffset? DateTime { get; set; }

        [JsonProperty(PropertyName = "dateTimeType")]
        public string DateTimeType { get; set; }

        [JsonProperty(PropertyName = "timeAdjustments")]
        public TimeAdjustments TimeAdjustments { get; set; }
    }
}