using NuvisoftBackend.Adapters.SQLServerDataAccess.Contexts;
using NuvisoftBackend.Core.Domain.Models;
using NuvisoftBackend.Core.Infraestructure.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvisoftBackend.Core.Infraestructure.Repository.Concrete
{
    public class PrivilegeRepository : IAuxiliaryRepository<Privilege, Guid>
    {
        private NuvisoftDB db;
        public PrivilegeRepository(NuvisoftDB db)
        {
            this.db = db;
        }
        public Privilege Create(Privilege privilege)
        {
            privilege.privilege_id = Guid.NewGuid();
            privilege.created_at = DateTime.Now;
            privilege.updated_at = DateTime.Now;
            db.Privileges.Add(privilege);
            return privilege;
        }

        public void Delete(Guid entityId)
        {
            var selectedPrivilege = db.Privileges
              .Where(v => v.privilege_id == entityId).FirstOrDefault();

            if (selectedPrivilege != null)
                db.Privileges.Remove(selectedPrivilege);
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Privilege Update(Privilege entity)
        {
            var selectedPrivilege = db.Privileges
              .Where(v => v.privilege_id == entity.privilege_id)
              .FirstOrDefault();

            if (selectedPrivilege != null)
            {
                selectedPrivilege.role_id = entity.role_id;
                selectedPrivilege.user_id = entity.user_id;
                selectedPrivilege.updated_at = DateTime.Now;
                selectedPrivilege.updated_by = entity.updated_by;

                db.Entry(selectedPrivilege).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedPrivilege;
        }
    }
}
