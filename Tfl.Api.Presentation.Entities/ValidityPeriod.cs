using System;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class ValidityPeriod
    {
        [JsonProperty(PropertyName = "fromDate")]
        public DateTimeOffset? FromDate { get; set; }

        [JsonProperty(PropertyName = "toDate")]
        public DateTimeOffset? ToDate { get; set; }

        [JsonProperty(PropertyName = "isNow")] public bool? IsNow { get; set; }
    }
}