using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NuvisoftBackend.Core.Domain.Models
{
    //Modelo Asignatura Horario
    public class SubjectSchedule
    {
        public Guid subject_schedule_id { get; set; }
        public Guid subject_id { get; set; }
        public Guid schedule_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Guid created_by { get; set; }
        public Guid updated_by { get; set; }
        [ForeignKey("subject_id")]
        [JsonPropertyName("Subject")]
        public Subject Subject { get; set; }
        [ForeignKey("schedule_id")]
        [JsonPropertyName("Schedule")]
        public Schedule Schedule { get; set; }
    }
}
