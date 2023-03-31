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
    public class GroupRepository : IBaseRepository<Group, Guid>
    {
        private NuvisoftDB db;
        public GroupRepository(NuvisoftDB db)
        {
            this.db = db;
        }

        public Group Create(Group group)
        {
            group.group_id = Guid.NewGuid();
            group.created_by =  Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            group.updated_by = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            group.created_at = DateTime.Now;
            group.updated_at = DateTime.Now;
            db.Groups.Add(group);
            return group;
        }

        public void Delete(Guid entityId)
        {
            var selectedGroup = db.Groups
              .Where(v => v.group_id == entityId).FirstOrDefault();

            if (selectedGroup != null)
                db.Groups.Remove(selectedGroup);
        }

        public List<Group> GetAll()
        {
            return db.Groups.Include(v => v.GroupStudent)
                .Include(v => v.GroupSubject).ToList();
        }

        public Group GetById(Guid entityId)
        {
            var selectedGroup = db.Groups
                .Where(v => v.group_id == entityId).FirstOrDefault();
            return selectedGroup;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Group Update(Group entity)
        {
            var selecteGroup = db.Groups
              .Where(v => v.group_id == entity.group_id)
              .FirstOrDefault();

            if (selecteGroup != null)
            {
                selecteGroup.name = entity.name;
                selecteGroup.year = entity.year;
                selecteGroup.section = entity.section;
                selecteGroup.updated_at = DateTime.Now;

                db.Entry(selecteGroup).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selecteGroup;
        }
    }
}
