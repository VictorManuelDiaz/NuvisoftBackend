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
    public class PrivilegeSubjectRepository : IAuxiliaryRepository<PrivilegeSubject, Guid>
    {
        private NuvisoftDB db;
        public PrivilegeSubjectRepository(NuvisoftDB db)
        {
            this.db = db;
        }

        public PrivilegeSubject Create(PrivilegeSubject privilegeSubject)
        {
            privilegeSubject.privilege_subject_id = Guid.NewGuid();
            privilegeSubject.created_at = DateTime.Now;
            privilegeSubject.updated_at = DateTime.Now;
            db.PrivilegesSubject.Add(privilegeSubject);
            return privilegeSubject;
        }

        public void Delete(Guid entityId)
        {
            var selectedPrivilegeSubject = db.PrivilegesSubject
              .Where(v => v.privilege_subject_id == entityId).FirstOrDefault();

            if (selectedPrivilegeSubject != null)
                db.PrivilegesSubject.Remove(selectedPrivilegeSubject);
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public PrivilegeSubject Update(PrivilegeSubject entity)
        {
            var selectedPrivilegeSubject = db.PrivilegesSubject
              .Where(v => v.privilege_subject_id == entity.privilege_subject_id)
              .FirstOrDefault();

            if (selectedPrivilegeSubject != null)
            {
                selectedPrivilegeSubject.privilege_id = entity.privilege_id;
                selectedPrivilegeSubject.subject_id = entity.subject_id;
                selectedPrivilegeSubject.updated_at = DateTime.Now;
                selectedPrivilegeSubject.updated_by = entity.updated_by;

                db.Entry(selectedPrivilegeSubject).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedPrivilegeSubject;
        }
    }
}
