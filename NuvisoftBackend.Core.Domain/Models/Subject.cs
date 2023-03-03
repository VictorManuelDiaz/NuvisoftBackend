using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NuvisoftBackend.Core.Domain.Models
{
    //Modelo Asignatura
    public class Subject
    {
        public Guid subject_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Guid created_by { get; set; }
        public Guid updated_by { get; set; }
        [JsonPropertyName("Templates")]
        public List<Template> Templates { get; set; }
        [JsonPropertyName("PrivilegesSubject")]
        public List<PrivilegeSubject> PrivilegesSubject { get; set; }
        [JsonPropertyName("SubjectSchedules")]
        public List<SubjectSchedule> SubjectSchedules { get; set; }
    }
}
