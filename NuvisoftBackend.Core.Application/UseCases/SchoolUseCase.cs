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
    public class SchoolUseCase : IBaseUseCase<School, Guid>
    {
        private readonly IBaseRepository<School, Guid> repository;

        public SchoolUseCase(IBaseRepository<School, Guid> repository)
        {
            this.repository = repository;
        }

        public School Create(School entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.SaveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. El colegio no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }

        public List<School> GetAll()
        {
            return repository.GetAll();
        }

        public School GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public School Update(School entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
