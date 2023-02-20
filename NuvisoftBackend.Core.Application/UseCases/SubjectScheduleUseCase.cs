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
    public class SubjectScheduleUseCase : IAuxiliaryUseCase<SubjectSchedule, Guid>
    {
        private readonly IAuxiliaryRepository<SubjectSchedule, Guid> repository;

        public SubjectScheduleUseCase(IAuxiliaryRepository<SubjectSchedule, Guid> repository)
        {
            this.repository = repository;
        }

        public SubjectSchedule Create(SubjectSchedule entity)
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

        public SubjectSchedule Update(SubjectSchedule entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
