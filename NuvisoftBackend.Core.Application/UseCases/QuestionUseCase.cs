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
    public class QuestionUseCase : IBaseUseCase<Question, Guid>
    {
        private readonly IBaseRepository<Question, Guid> repository;

        public QuestionUseCase(IBaseRepository<Question, Guid> repository)
        {
            this.repository = repository;
        }
        public Question Create(Question entity)
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

        public List<Question> GetAll()
        {
            return repository.GetAll();
        }

        public Question GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Question Update(Question entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
