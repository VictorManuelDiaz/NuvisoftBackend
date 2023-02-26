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
    public class SchoolRepository : IBaseRepository<School, Guid>
    {
        private NuvisoftDB db;
        public SchoolRepository(NuvisoftDB db)
        {
            this.db = db;
        }
        public School Create(School school)
        {
            school.school_id = Guid.NewGuid();
            school.created_by = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            school.updated_by = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            school.created_at = DateTime.Now;
            school.updated_at = DateTime.Now;
            db.Schools.Add(school);
            return school;
        }

        public void Delete(Guid entityId)
        {
            var selectedSchool = db.Schools
              .Where(v => v.school_id == entityId).FirstOrDefault();

            if (selectedSchool != null)
                db.Schools.Remove(selectedSchool);
        }

        public List<School> GetAll()
        {
            return db.Schools.ToList();
        }

        public School GetById(Guid entityId)
        {
            var selectedSchool = db.Schools
                .Where(v => v.school_id == entityId).FirstOrDefault();
            return selectedSchool;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public School Update(School entity)
        {
            var selectedSchool = db.Schools
              .Where(v => v.school_id == entity.school_id)
              .FirstOrDefault();

            if (selectedSchool != null)
            {
                selectedSchool.name = entity.name;
                selectedSchool.description = entity.description;
                selectedSchool.location = entity.location;
                selectedSchool.address = entity.address;
                selectedSchool.logo = entity.logo;
                selectedSchool.email = entity.email;
                selectedSchool.phone = entity.phone;
                selectedSchool.updated_at = DateTime.Now;

                db.Entry(selectedSchool).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedSchool;
        }
    }
}
