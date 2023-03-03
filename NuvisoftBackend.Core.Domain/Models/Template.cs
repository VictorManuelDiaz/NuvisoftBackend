using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NuvisoftBackend.Core.Domain.Models
{
    //Modelo Plantillas
    public class Template
    {
        public Guid template_id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public Guid subject_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Guid created_by { get; set; }
        public Guid updated_by { get; set; }
        [ForeignKey("subject_id")]
        [JsonPropertyName("Subject")]
        public Subject Subject { get; set; }
        [JsonPropertyName("Questions")]
        public List<Question> Questions { get; set; }
        [JsonPropertyName("Jobs")]
        public List<Job> Jobs { get; set; }

    }
}
