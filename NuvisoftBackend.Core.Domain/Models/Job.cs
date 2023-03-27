using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NuvisoftBackend.Core.Domain.Models
{
    // Modelo Trabajos
    public class Job
    {
        public Guid job_id { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public Guid template_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Guid created_by { get; set; }
        public Guid updated_by { get; set; }
        [ForeignKey("template_id")]
        [JsonPropertyName("Template")]
        public Template Template { get; set; }
        [JsonPropertyName("Grades")]
        public List<Grade> Grades { get; set; }
    }
}
