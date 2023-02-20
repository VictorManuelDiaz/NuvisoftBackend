using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvisoftBackend.Core.Domain.Models
{
    //Modelo Horario
    public class Schedule
    {
        public Guid schedule_id { get; set; }
        public string name { get; set; }
        public string modality { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Guid created_by { get; set; }
        public Guid updated_by { get; set; }
        public List<SubjectSchedule> SubjectSchedules { get; set; }
    }
}
