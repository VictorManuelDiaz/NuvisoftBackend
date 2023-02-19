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
    public class UserRepository : IBaseRepository<User, Guid>
    {
        private NuvisoftDB db;
        public UserRepository(NuvisoftDB db)
        {
            this.db = db;
        }
        public User Create(User user)
        {
            user.user_id = Guid.NewGuid();
            user.created_at = DateTime.Now;
            user.updated_at = DateTime.Now;
            db.Users.Add(user);
            return user;
        }

        public void Delete(Guid entityId)
        {
            var selectedUser = db.Users
              .Where(v => v.user_id == entityId).FirstOrDefault();

            if (selectedUser != null)
                db.Users.Remove(selectedUser);
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public User GetById(Guid entityId)
        {
            var selectedUser = db.Users
                .Where(v => v.user_id == entityId).FirstOrDefault();
            return selectedUser;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public User Update(User entity)
        {
            var selectedUser = db.Users
              .Where(v => v.user_id == entity.user_id)
              .FirstOrDefault();

            if (selectedUser != null)
            {
                selectedUser.name = entity.name;
                selectedUser.last_name = entity.last_name;
                selectedUser.email = entity.email;
                selectedUser.password = entity.password;
                selectedUser.id_card = entity.id_card;
                selectedUser.school_id = entity.school_id;
                selectedUser.updated_at = DateTime.Now;
                selectedUser.updated_by = entity.updated_by;

                db.Entry(selectedUser).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedUser;
        }
    }
}
