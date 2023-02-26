using NuvisoftBackend.Adapters.SQLServerDataAccess.Contexts;
using NuvisoftBackend.Adapters.SQLServerDataAccess.Entities;
using NuvisoftBackend.Core.Domain.Models;
using NuvisoftBackend.Core.Infraestructure.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvisoftBackend.Core.Infraestructure.Repository.Concrete
{
    public class SubjectScheduleRepository : IAuxiliaryRepository<SubjectSchedule, Guid>
    {
        private NuvisoftDB db;
        public SubjectScheduleRepository(NuvisoftDB db)
        {
            this.db = db;
        }

        public SubjectSchedule Create(SubjectSchedule subjectSchedule)
        {
            subjectSchedule.subject_schedule_id = Guid.NewGuid();
            subjectSchedule.created_by = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            subjectSchedule.updated_by = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            subjectSchedule.created_at = DateTime.Now;
            subjectSchedule.updated_at = DateTime.Now;
            db.SubjectSchedules.Add(subjectSchedule);
            return subjectSchedule;
        }

        public void Delete(Guid entityId)
        {
            var selectedSubjectSchedule = db.SubjectSchedules
              .Where(v => v.subject_schedule_id == entityId).FirstOrDefault();

            if (selectedSubjectSchedule != null)
                db.SubjectSchedules.Remove(selectedSubjectSchedule);
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public SubjectSchedule Update(SubjectSchedule entity)
        {
            var selectedSubjectSchedule = db.SubjectSchedules
              .Where(v => v.subject_schedule_id == entity.subject_schedule_id)
              .FirstOrDefault();

            if (selectedSubjectSchedule != null)
            {
                selectedSubjectSchedule.subject_id = entity.subject_id;
                selectedSubjectSchedule.schedule_id = entity.schedule_id;
                selectedSubjectSchedule.updated_at = DateTime.Now;

                db.Entry(selectedSubjectSchedule).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedSubjectSchedule;
        }
    }
}
