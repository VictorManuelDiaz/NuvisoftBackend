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
    public class GroupSubjectUseCase : IAuxiliaryUseCase<GroupSubject, Guid>
    {
        private readonly IAuxiliaryRepository<GroupSubject, Guid> repository;

        public GroupSubjectUseCase(IAuxiliaryRepository<GroupSubject, Guid> repository)
        {
            this.repository = repository;
        }

        public GroupSubject Create(GroupSubject entity)
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

        public GroupSubject Update(GroupSubject entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
