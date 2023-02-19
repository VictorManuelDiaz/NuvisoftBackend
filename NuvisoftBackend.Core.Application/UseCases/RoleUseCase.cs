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
    public class RoleUseCase : IAuxiliaryUseCase<Role, Guid>
    {
        private readonly IAuxiliaryRepository<Role, Guid> repository;

        public RoleUseCase(IAuxiliaryRepository<Role, Guid> repository)
        {
            this.repository = repository;
        }

        public Role Create(Role entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.SaveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. La información no es válida");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }

        public Role Update(Role entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
