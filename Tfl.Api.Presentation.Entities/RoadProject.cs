using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class RoadProject
    {
        [JsonProperty(PropertyName = "projectId")]
        public string ProjectId { get; set; }

        [JsonProperty(PropertyName = "schemeName")]
        public string SchemeName { get; set; }

        [JsonProperty(PropertyName = "projectName")]
        public string ProjectName { get; set; }

        [JsonProperty(PropertyName = "projectDescription")]
        public string ProjectDescription { get; set; }

        [JsonProperty(PropertyName = "projectPageUrl")]
        public string ProjectPageUrl { get; set; }

        [JsonProperty(PropertyName = "consultationPageUrl")]
        public string ConsultationPageUrl { get; set; }

        [JsonProperty(PropertyName = "consultationStartDate")]
        public DateTimeOffset? ConsultationStartDate { get; set; }

        [JsonProperty(PropertyName = "consultationEndDate")]
        public DateTimeOffset? ConsultationEndDate { get; set; }

        [JsonProperty(PropertyName = "constructionStartDate")]
        public DateTimeOffset? ConstructionStartDate { get; set; }

        [JsonProperty(PropertyName = "constructionEndDate")]
        public DateTimeOffset? ConstructionEndDate { get; set; }

        [JsonProperty(PropertyName = "boroughsBenefited")]
        public List<string> BoroughsBenefited { get; set; }

        [JsonProperty(PropertyName = "cycleSuperhighwayId")]
        public string CycleSuperhighwayId { get; set; }

        [JsonProperty(PropertyName = "phase")] public string Phase { get; set; }

        [JsonProperty(PropertyName = "contactName")]
        public string ContactName { get; set; }

        [JsonProperty(PropertyName = "contactEmail")]
        public string ContactEmail { get; set; }

        [JsonProperty(PropertyName = "externalPageUrl")]
        public string ExternalPageUrl { get; set; }

        [JsonProperty(PropertyName = "projectSummaryPageUrl")]
        public string ProjectSummaryPageUrl { get; set; }
    }
}