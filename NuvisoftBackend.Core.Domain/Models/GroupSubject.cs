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
    public class GroupSubject
    {
        public Guid group_subject_id { get; set; }
        public Guid group_id { get; set; }
        public Guid subject_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Guid created_by { get; set; }
        public Guid updated_by { get; set; }
        [ForeignKey("group_id")]
        [JsonPropertyName("Group")]
        public Group Group { get; set; }
        [ForeignKey("subject_id")]
        [JsonPropertyName("Subject")]
        [JsonIgnore]
        public Subject Subject { get; set; }

    }
}
