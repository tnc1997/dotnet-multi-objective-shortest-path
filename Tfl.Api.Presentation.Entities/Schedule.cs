using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class Schedule
    {
        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "knownJourneys")]
        public List<KnownJourney> KnownJourneys { get; set; }

        [JsonProperty(PropertyName = "firstJourney")]
        public KnownJourney FirstJourney { get; set; }

        [JsonProperty(PropertyName = "lastJourney")]
        public KnownJourney LastJourney { get; set; }

        [JsonProperty(PropertyName = "periods")]
        public List<Period> Periods { get; set; }
    }
}