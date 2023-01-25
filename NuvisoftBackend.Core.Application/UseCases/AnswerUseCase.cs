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
    public class AnswerUseCase : IBaseUseCase<Answer, Guid>
    {
        private readonly IBaseRepository<Answer, Guid> repository;

        public AnswerUseCase(IBaseRepository<Answer, Guid> repository)
        {
            this.repository = repository;
        }
        public Answer Create(Answer entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.SaveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. La plantilla no puede ser nula");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }

        public List<Answer> GetAll()
        {
            return repository.GetAll();
        }

        public Answer GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Answer Update(Answer entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
