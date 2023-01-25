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
    public class SubjectUseCase : IBaseUseCase<Subject, Guid>
    {
        private readonly IBaseRepository<Subject, Guid> repository;

        public SubjectUseCase(IBaseRepository<Subject, Guid> repository)
        {
            this.repository = repository;
        }

        public Subject Create(Subject entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.SaveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. La asignatura no puede ser nula");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }

        public List<Subject> GetAll()
        {
            return repository.GetAll();
        }

        public Subject GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Subject Update(Subject entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
