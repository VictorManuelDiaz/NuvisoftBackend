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
    public class GroupUseCase : IBaseUseCase<Group, Guid>
    {
        private readonly IBaseRepository<Group, Guid> repository;

        public GroupUseCase(IBaseRepository<Group, Guid> repository)
        {
            this.repository = repository;
        }
        public Group Create(Group entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.SaveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. El grupo no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }

        public List<Group> GetAll()
        {
            return repository.GetAll();
        }

        public Group GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Group Update(Group entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
