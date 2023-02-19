using NuvisoftBackend.Core.Application.Interfaces;
using NuvisoftBackend.Core.Domain.Models;
using NuvisoftBackend.Core.Infraestructure.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvisoftBackend.Core.Application.UseCases
{
    public class UserUseCase : IBaseUseCase<User, Guid>
    {
        private readonly IBaseRepository<User, Guid> repository;

        public UserUseCase(IBaseRepository<User, Guid> repository)
        {
            this.repository = repository;
        }

        public User Create(User entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.SaveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. El usuario no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }

        public List<User> GetAll()
        {
            return repository.GetAll();
        }

        public User GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public User Update(User entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
