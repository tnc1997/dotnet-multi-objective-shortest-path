using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class TimetablesDisambiguation
    {
        [JsonProperty(PropertyName = "disambiguationOptions")]
        public List<TimetablesDisambiguationOption> DisambiguationOptions { get; set; }
    }
}