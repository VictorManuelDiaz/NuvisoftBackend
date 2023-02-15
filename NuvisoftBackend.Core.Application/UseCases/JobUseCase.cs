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
    public class JobUseCase : IBaseUseCase<Job, Guid>
    {
        private readonly IBaseRepository<Job, Guid> repository;

        public JobUseCase(IBaseRepository<Job, Guid> repository)
        {
            this.repository = repository;
        }
        public Job Create(Job entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.SaveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. El trabajo no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }

        public List<Job> GetAll()
        {
            return repository.GetAll();
        }

        public Job GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Job Update(Job entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
