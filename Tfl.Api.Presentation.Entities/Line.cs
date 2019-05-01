using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class Line : IEquatable<Line>
    {
        [JsonProperty(PropertyName = "id")] public string Id { get; set; }

        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "modeName")]
        public string ModeName { get; set; }

        [JsonProperty(PropertyName = "disruptions")]
        public List<Disruption> Disruptions { get; set; }

        [JsonProperty(PropertyName = "created")]
        public DateTimeOffset? Created { get; set; }

        [JsonProperty(PropertyName = "modified")]
        public DateTimeOffset? Modified { get; set; }

        [JsonProperty(PropertyName = "lineStatuses")]
        public List<LineStatus> LineStatuses { get; set; }

        [JsonProperty(PropertyName = "routeSections")]
        public List<MatchedRoute> RouteSections { get; set; }

        [JsonProperty(PropertyName = "serviceTypes")]
        public List<LineServiceTypeInfo> ServiceTypes { get; set; }

        [JsonProperty(PropertyName = "crowding")]
        public Crowding Crowding { get; set; }

        public bool Equals(Line other)
        {
            if (ReferenceEquals(null, other)) return false;

            if (ReferenceEquals(this, other)) return true;

            return string.Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;

            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != GetType()) return false;

            return Equals((Line) obj);
        }

        public override int GetHashCode()
        {
            return Id != null ? Id.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}