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
    public class ScheduleUseCase : IBaseUseCase<Schedule, Guid>
    {
        private readonly IBaseRepository<Schedule, Guid> repository;

        public ScheduleUseCase(IBaseRepository<Schedule, Guid> repository)
        {
            this.repository = repository;
        }

        public Schedule Create(Schedule entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.SaveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. El horario no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }

        public List<Schedule> GetAll()
        {
            return repository.GetAll();
        }

        public Schedule GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Schedule Update(Schedule entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
