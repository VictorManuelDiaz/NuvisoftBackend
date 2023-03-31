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
    public class GroupStudentRepository : IAuxiliaryRepository<GroupStudent, Guid>
    {
        private NuvisoftDB db;
        public GroupStudentRepository(NuvisoftDB db)
        {
            this.db = db;
        }

        public GroupStudent Create(GroupStudent groupStudent)
        {
            groupStudent.group_student_id = Guid.NewGuid();
            groupStudent.created_by = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            groupStudent.updated_by = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            groupStudent.created_at = DateTime.Now;
            groupStudent.updated_at = DateTime.Now;
            db.GroupsStudent.Add(groupStudent);
            return groupStudent;
        }

        public void Delete(Guid entityId)
        {
            var selectedGroupStudent = db.GroupsStudent
              .Where(v => v.group_student_id == entityId).FirstOrDefault();

            if (selectedGroupStudent != null)
                db.GroupsStudent.Remove(selectedGroupStudent);
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public GroupStudent Update(GroupStudent entity)
        {
            var selectedGroupStudent = db.GroupsStudent
              .Where(v => v.group_student_id == entity.group_student_id)
              .FirstOrDefault();

            if (selectedGroupStudent != null)
            {
                selectedGroupStudent.group_id = entity.group_id;
                selectedGroupStudent.student_id = entity.student_id;
                selectedGroupStudent.updated_at = DateTime.Now;

                db.Entry(selectedGroupStudent).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedGroupStudent;
        }
    }
}
