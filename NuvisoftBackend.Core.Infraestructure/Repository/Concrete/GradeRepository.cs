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
    public class GradeRepository : IBaseRepository<Grade, Guid>
    {
        private NuvisoftDB db;
        public GradeRepository(NuvisoftDB db)
        {
            this.db = db;
        }

        public Grade Create(Grade grade)
        {
            grade.grade_id = Guid.NewGuid();
            grade.created_by = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            grade.updated_by = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            grade.created_at = DateTime.Now;
            grade.updated_at = DateTime.Now;
            db.Grades.Add(grade);
            return grade;
        }

        public void Delete(Guid entityId)
        {
            var selectedGrade = db.Grades
              .Where(v => v.grade_id == entityId).FirstOrDefault();

            if (selectedGrade != null)
                db.Grades.Remove(selectedGrade);
        }
 
        public List<Grade> GetAll()
        {
            return db.Grades.ToList();
        }

        public Grade GetById(Guid entityId)
        {
            var selectedGrade = db.Grades
                .Where(v => v.grade_id == entityId).FirstOrDefault();
            return selectedGrade;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Grade Update(Grade entity)
        {
            var selecteGrade = db.Grades
              .Where(v => v.grade_id == entity.grade_id)
              .FirstOrDefault();

            if (selecteGrade != null)
            {
                selecteGrade.score = entity.score;
                selecteGrade.job_id = entity.job_id;
                selecteGrade.user_id = entity.user_id;
                selecteGrade.updated_at = DateTime.Now;

                db.Entry(selecteGrade).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selecteGrade;
        }
    }
}
