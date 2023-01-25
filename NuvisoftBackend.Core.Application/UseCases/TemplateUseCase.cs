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
    public class TemplateUseCase : IBaseUseCase<Template, Guid>
    {
        private readonly IBaseRepository<Template, Guid> repository;

        public TemplateUseCase(IBaseRepository<Template, Guid> repository)
        {
            this.repository = repository;
        }

        public Template Create(Template entity)
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

        public List<Template> GetAll()
        {
            return repository.GetAll();
        }

        public Template GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Template Update(Template entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
