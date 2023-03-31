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
    public class GroupSubjectRepository : IAuxiliaryRepository<GroupSubject, Guid>
    {
        private NuvisoftDB db;
        public GroupSubjectRepository(NuvisoftDB db)
        {
            this.db = db;
        }

        public GroupSubject Create(GroupSubject groupSubject)
        {
            groupSubject.group_subject_id = Guid.NewGuid();
            groupSubject.created_by = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            groupSubject.updated_by = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            groupSubject.created_at = DateTime.Now;
            groupSubject.updated_at = DateTime.Now;
            db.GroupsSubject.Add(groupSubject);
            return groupSubject;
        }

        public void Delete(Guid entityId)
        {
            var selectedGroupSubject = db.GroupsSubject
              .Where(v => v.group_subject_id == entityId).FirstOrDefault();

            if (selectedGroupSubject != null)
                db.GroupsSubject.Remove(selectedGroupSubject);
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public GroupSubject Update(GroupSubject entity)
        {
            var selectedGroupSubject = db.GroupsSubject
              .Where(v => v.group_subject_id == entity.group_subject_id)
              .FirstOrDefault();

            if (selectedGroupSubject != null)
            {
                selectedGroupSubject.group_id = entity.group_id;
                selectedGroupSubject.subject_id = entity.subject_id;
                selectedGroupSubject.updated_at = DateTime.Now;

                db.Entry(selectedGroupSubject).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedGroupSubject;
        }
    }
}
