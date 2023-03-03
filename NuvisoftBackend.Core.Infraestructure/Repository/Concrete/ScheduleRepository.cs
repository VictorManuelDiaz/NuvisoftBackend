using Microsoft.EntityFrameworkCore;
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
    public class ScheduleRepository : IBaseRepository<Schedule, Guid>
    {
        private NuvisoftDB db;
        public ScheduleRepository(NuvisoftDB db)
        {
            this.db = db;
        }

        public Schedule Create(Schedule schedule)
        {
            schedule.schedule_id = Guid.NewGuid();
            schedule.created_by = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            schedule.updated_by = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            schedule.created_at = DateTime.Now;
            schedule.updated_at = DateTime.Now;
            db.Schedules.Add(schedule);
            return schedule;
        }

        public void Delete(Guid entityId)
        {
            var selectedSchedule = db.Schedules
              .Where(v => v.schedule_id == entityId).FirstOrDefault();

            if (selectedSchedule != null)
                db.Schedules.Remove(selectedSchedule);
        }

        public List<Schedule> GetAll()
        {
            return db.Schedules.Include(schedule => schedule.SubjectSchedules).ToList();
        }

        public Schedule GetById(Guid entityId)
        {
            var selectedSchedule = db.Schedules.Include(schedule => schedule.SubjectSchedules)
                .Where(v => v.schedule_id == entityId).FirstOrDefault();
            return selectedSchedule;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Schedule Update(Schedule entity)
        {
            var selectedSchedule = db.Schedules
              .Where(v => v.schedule_id == entity.schedule_id)
              .FirstOrDefault();

            if (selectedSchedule != null)
            {
                selectedSchedule.name = entity.name;
                selectedSchedule.modality = entity.modality;
                selectedSchedule.updated_at = DateTime.Now;

                db.Entry(selectedSchedule).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedSchedule;
        }
    }
}
