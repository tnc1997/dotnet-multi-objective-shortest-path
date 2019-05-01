using System;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class PredictionTiming
    {
        [JsonProperty(PropertyName = "countdownServerAdjustment")]
        public string CountdownServerAdjustment { get; set; }

        [JsonProperty(PropertyName = "source")]
        public DateTimeOffset? Source { get; set; }

        [JsonProperty(PropertyName = "insert")]
        public DateTimeOffset? Insert { get; set; }

        [JsonProperty(PropertyName = "read")] public DateTimeOffset? Read { get; set; }

        [JsonProperty(PropertyName = "sent")] public DateTimeOffset? Sent { get; set; }

        [JsonProperty(PropertyName = "received")]
        public DateTimeOffset? Received { get; set; }
    }
}