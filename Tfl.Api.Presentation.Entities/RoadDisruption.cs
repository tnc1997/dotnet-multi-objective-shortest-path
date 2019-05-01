using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class RoadDisruption
    {
        [JsonProperty(PropertyName = "id")] public string Id { get; set; }

        [JsonProperty(PropertyName = "url")] public string Url { get; set; }

        [JsonProperty(PropertyName = "point")] public string Point { get; set; }

        [JsonProperty(PropertyName = "severity")]
        public string Severity { get; set; }

        [JsonProperty(PropertyName = "ordinal")]
        public int? Ordinal { get; set; }

        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "subCategory")]
        public string SubCategory { get; set; }

        [JsonProperty(PropertyName = "comments")]
        public string Comments { get; set; }

        [JsonProperty(PropertyName = "currentUpdate")]
        public string CurrentUpdate { get; set; }

        [JsonProperty(PropertyName = "currentUpdateDateTime")]
        public DateTimeOffset? CurrentUpdateDateTime { get; set; }

        [JsonProperty(PropertyName = "corridorIds")]
        public List<string> CorridorIds { get; set; }

        [JsonProperty(PropertyName = "startDateTime")]
        public DateTimeOffset? StartDateTime { get; set; }

        [JsonProperty(PropertyName = "endDateTime")]
        public DateTimeOffset? EndDateTime { get; set; }

        [JsonProperty(PropertyName = "lastModifiedTime")]
        public DateTimeOffset? LastModifiedTime { get; set; }

        [JsonProperty(PropertyName = "levelOfInterest")]
        public string LevelOfInterest { get; set; }

        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "geography")]
        public DbGeography Geography { get; set; }

        [JsonProperty(PropertyName = "geometry")]
        public DbGeography Geometry { get; set; }

        [JsonProperty(PropertyName = "streets")]
        public List<Street> Streets { get; set; }

        [JsonProperty(PropertyName = "isProvisional")]
        public bool? IsProvisional { get; set; }

        [JsonProperty(PropertyName = "hasClosures")]
        public bool? HasClosures { get; set; }

        [JsonProperty(PropertyName = "linkText")]
        public string LinkText { get; set; }

        [JsonProperty(PropertyName = "linkUrl")]
        public string LinkUrl { get; set; }

        [JsonProperty(PropertyName = "roadProject")]
        public RoadProject RoadProject { get; set; }

        [JsonProperty(PropertyName = "publishStartDate")]
        public DateTimeOffset? PublishStartDate { get; set; }

        [JsonProperty(PropertyName = "publishEndDate")]
        public DateTimeOffset? PublishEndDate { get; set; }

        [JsonProperty(PropertyName = "timeFrame")]
        public string TimeFrame { get; set; }

        [JsonProperty(PropertyName = "roadDisruptionLines")]
        public List<RoadDisruptionLine> RoadDisruptionLines { get; set; }

        [JsonProperty(PropertyName = "roadDisruptionImpactAreas")]
        public List<RoadDisruptionImpactArea> RoadDisruptionImpactAreas { get; set; }

        [JsonProperty(PropertyName = "recurringSchedules")]
        public List<RoadDisruptionSchedule> RecurringSchedules { get; set; }
    }
}