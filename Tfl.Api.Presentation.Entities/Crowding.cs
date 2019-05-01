using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class Crowding
    {
        [JsonProperty(PropertyName = "passengerFlows")]
        public List<PassengerFlow> PassengerFlows { get; set; }

        [JsonProperty(PropertyName = "trainLoadings")]
        public List<TrainLoading> TrainLoadings { get; set; }
    }
}