using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class TimetableResponse
    {
        [JsonProperty(PropertyName = "lineId")]
        public string LineId { get; set; }

        [JsonProperty(PropertyName = "lineName")]
        public string LineName { get; set; }

        [JsonProperty(PropertyName = "direction")]
        public string Direction { get; set; }

        [JsonProperty(PropertyName = "pdfUrl")]
        public string PdfUrl { get; set; }

        [JsonProperty(PropertyName = "stations")]
        public List<MatchedStop> Stations { get; set; }

        [JsonProperty(PropertyName = "stops")] public List<MatchedStop> Stops { get; set; }

        [JsonProperty(PropertyName = "timetable")]
        public Timetable Timetable { get; set; }

        [JsonProperty(PropertyName = "disambiguation")]
        public TimetablesDisambiguation Disambiguation { get; set; }

        [JsonProperty(PropertyName = "statusErrorMessage")]
        public string StatusErrorMessage { get; set; }
    }
}