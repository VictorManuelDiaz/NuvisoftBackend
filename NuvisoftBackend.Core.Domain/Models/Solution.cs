using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NuvisoftBackend.Core.Domain.Models
{
    public class Solution
    {
        public Guid solution_id { get; set; }
        public string answer { get; set; }
        public int score { get; set; }
        public Guid job_id { get; set; }
        public Guid question_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Guid created_by { get; set; }
        public Guid updated_by { get; set; }
        [ForeignKey("job_id")]
        [JsonPropertyName("Job")]
        public Job Job { get; set; }
        [ForeignKey("question_id")]
        [JsonPropertyName("Question")]
        public Question Question { get; set; }
    }
}
