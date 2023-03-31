using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NuvisoftBackend.Core.Domain.Models
{
    public class Group
    {
        public Guid group_id { get; set; }
        public string section { get; set; }
        public string name { get; set; }
        public int year { get; set; }
        public Guid school_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Guid created_by { get; set; }
        public Guid updated_by { get; set; }
        [JsonPropertyName("GroupSubject")]
        public List<GroupSubject> GroupSubject { get; set; }
        [JsonPropertyName("GroupStudent")]
        public List<GroupStudent> GroupStudent { get; set; }
        [ForeignKey("school_id")]
        [JsonPropertyName("School")]
        public School School { get; set; }
    }
}
