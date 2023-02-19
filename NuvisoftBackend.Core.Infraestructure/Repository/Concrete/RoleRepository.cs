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
    public class RoleRepository : IAuxiliaryRepository<Role, Guid>
    {
        private NuvisoftDB db;
        public RoleRepository(NuvisoftDB db)
        {
            this.db = db;
        }

        public Role Create(Role role)
        {
            role.role_id = Guid.NewGuid();
            role.created_at = DateTime.Now;
            role.updated_at = DateTime.Now;
            db.Roles.Add(role);
            return role;
        }

        public void Delete(Guid entityId)
        {
            var selectedRole = db.Roles
              .Where(v => v.role_id == entityId).FirstOrDefault();

            if (selectedRole != null)
                db.Roles.Remove(selectedRole);
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Role Update(Role entity)
        {
            var selectedRole = db.Roles
              .Where(v => v.role_id == entity.role_id)
              .FirstOrDefault();

            if (selectedRole != null)
            {
                selectedRole.role_name = entity.role_name;
                selectedRole.description = entity.description;
                selectedRole.updated_at = DateTime.Now;
                selectedRole.updated_by = entity.updated_by;

                db.Entry(selectedRole).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedRole;
        }
    }
}
