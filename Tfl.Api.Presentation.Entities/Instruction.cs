using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class Instruction
    {
        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        [JsonProperty(PropertyName = "detailed")]
        public string Detailed { get; set; }

        [JsonProperty(PropertyName = "steps")] public List<InstructionStep> Steps { get; set; }
    }
}