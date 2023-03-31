using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NuvisoftBackend.Core.Domain.Models
{
    //Modelo Privilegios_Asignatura
    public class GroupStudent
    {
        public Guid group_student_id { get; set; }
        public Guid group_id { get; set; }
        public Guid student_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Guid created_by { get; set; }
        public Guid updated_by { get; set; }
        [ForeignKey("group_id")]
        [JsonPropertyName("Group")]
        public Group Group { get; set; }
        [ForeignKey("student_id")]
        [JsonPropertyName("Student")]
        public User Student { get; set; }

    }
}
