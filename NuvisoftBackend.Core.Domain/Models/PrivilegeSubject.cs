using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvisoftBackend.Core.Domain.Models
{
    //Modelo Privilegios_Asignatura
    public class PrivilegeSubject
    {
        public Guid privilege_subject_id { get; set; }
        public Guid privilege_id { get; set; }
        public Guid subject_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Guid created_by { get; set; }
        public Guid updated_by { get; set; }
        [ForeignKey("privilege_id")]
        public Privilege Privilege { get; set; }
        [ForeignKey("subject_id")]
        public Subject Subject { get; set; }

    }
}
