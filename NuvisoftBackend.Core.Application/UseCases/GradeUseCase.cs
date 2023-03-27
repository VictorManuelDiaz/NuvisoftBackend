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
    public class GradeUseCase : IBaseUseCase<Grade, Guid>
    {
        private readonly IBaseRepository<Grade, Guid> repository;

        public GradeUseCase(IBaseRepository<Grade, Guid> repository)
        {
            this.repository = repository;
        }

        public Grade Create(Grade entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.SaveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. La calificación no puede ser nula");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }

        public List<Grade> GetAll()
        {
            return repository.GetAll();
        }

        public Grade GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Grade Update(Grade entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
