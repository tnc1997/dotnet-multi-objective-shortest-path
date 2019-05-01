using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class Timetable
    {
        [JsonProperty(PropertyName = "departureStopId")]
        public string DepartureStopId { get; set; }

        [JsonProperty(PropertyName = "routes")]
        public List<TimetableRoute> Routes { get; set; }
    }
}