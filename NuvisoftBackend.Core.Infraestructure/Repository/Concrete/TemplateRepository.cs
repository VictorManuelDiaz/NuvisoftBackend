using Microsoft.EntityFrameworkCore;
using NuvisoftBackend.Adapters.SQLServerDataAccess.Contexts;
using NuvisoftBackend.Adapters.SQLServerDataAccess.Entities;
using NuvisoftBackend.Core.Domain.Models;
using NuvisoftBackend.Core.Infraestructure.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvisoftBackend.Core.Infraestructure.Repository.Concrete
{
    public class TemplateRepository : IBaseRepository<Template, Guid>
    {
        private NuvisoftDB db;
        public TemplateRepository(NuvisoftDB db)
        {
            this.db = db;
        }
        public Template Create(Template template)
        {
            template.template_id = Guid.NewGuid();
            template.created_at = DateTime.Now;
            template.updated_at = DateTime.Now;
            db.Templates.Add(template);
            return template;
        }

        public void Delete(Guid entityId)
        {
            var selectedTemplate = db.Templates
              .Where(v => v.template_id == entityId).FirstOrDefault();

            if (selectedTemplate != null)
                db.Templates.Remove(selectedTemplate);
        }

        public List<Template> GetAll()
        {
            return db.Templates.Include(template => template.Subject)
                .Include(template => template.Questions)
                .Include(template => template.Jobs).ToList();
        }

        public Template GetById(Guid entityId)
        {
            var selectedTemplate = db.Templates.Include(template => template.Subject)
                .Include(template => template.Questions)
                .Include(template => template.Jobs)
                .Where(v => v.template_id == entityId).FirstOrDefault();
            return selectedTemplate;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Template Update(Template entity)
        {
            var selectedTemplate = db.Templates
              .Where(v => v.template_id == entity.template_id)
              .FirstOrDefault();

            if (selectedTemplate != null)
            {
                selectedTemplate.title = entity.title;
                selectedTemplate.type = entity.type;
                selectedTemplate.description = entity.description;
                selectedTemplate.subject_id = entity.subject_id;
                selectedTemplate.updated_at = DateTime.Now;

                db.Entry(selectedTemplate).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedTemplate;
        }
    }
}
