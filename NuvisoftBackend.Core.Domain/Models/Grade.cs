using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NuvisoftBackend.Core.Domain.Models
{
    public class Grade
    {
        public Guid grade_id { get; set; }
        public int score { get; set; }
        public Guid job_id { get; set; }
        public Guid user_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Guid created_by { get; set; }
        public Guid updated_by { get; set; }
        [ForeignKey("job_id")]
        [JsonPropertyName("Job")]
        public Job Job { get; set; }
        [ForeignKey("user_id")]
        [JsonPropertyName("Student")]
        public User Student { get; set; }
    }
}
