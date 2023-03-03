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
    public class SubjectRepository : IBaseRepository<Subject, Guid>
    {
        private NuvisoftDB db;
        public SubjectRepository(NuvisoftDB db)
        {
            this.db = db;
        }

        public Subject Create(Subject subject)
        {
            subject.subject_id = Guid.NewGuid();
            subject.created_by = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            subject.updated_by = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            subject.created_at = DateTime.Now;
            subject.updated_at = DateTime.Now;
            db.Subjects.Add(subject);
            return subject;
        }

        public void Delete(Guid entityId)
        {
            var selectedSubject = db.Subjects
               .Where(v => v.subject_id == entityId).FirstOrDefault();

            if (selectedSubject != null)
                db.Subjects.Remove(selectedSubject);
        }

        public List<Subject> GetAll()
        {
            return db.Subjects.Include(subject => subject.Templates)
                .Include(subject => subject.PrivilegesSubject)
                .Include(subject => subject.SubjectSchedules).ToList();
        }

        public Subject GetById(Guid entityId)
        {
            var selectedSubject = db.Subjects.Include(subject => subject.Templates)
                .Include(subject => subject.PrivilegesSubject)
                .Include(subject => subject.SubjectSchedules)
                .Where(v => v.subject_id == entityId).FirstOrDefault();
            return selectedSubject;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Subject Update(Subject entity)
        {
            var selectedSubject = db.Subjects
               .Where(v => v.subject_id == entity.subject_id)
               .FirstOrDefault();

            if (selectedSubject != null)
            {
                selectedSubject.name = entity.name;
                selectedSubject.description = entity.description;
                selectedSubject.updated_at = DateTime.Now;

                db.Entry(selectedSubject).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedSubject;
        }
    }
}
