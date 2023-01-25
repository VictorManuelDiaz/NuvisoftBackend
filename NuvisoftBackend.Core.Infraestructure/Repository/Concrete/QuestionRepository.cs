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
    public class QuestionRepository : IBaseRepository<Question, Guid>
    {
        private NuvisoftDB db;
        public QuestionRepository(NuvisoftDB db)
        {
            this.db = db;
        }

        public Question Create(Question question)
        {
            question.question_id = Guid.NewGuid();
            question.created_at = DateTime.Now;
            question.updated_at = DateTime.Now;
            db.Questions.Add(question);
            return question;
        }

        public void Delete(Guid entityId)
        {
            var selectedQuestion = db.Questions
              .Where(v => v.question_id == entityId).FirstOrDefault();

            if (selectedQuestion != null)
                db.Questions.Remove(selectedQuestion);
        }

        public List<Question> GetAll()
        {
            return db.Questions.ToList();
        }

        public Question GetById(Guid entityId)
        {
            var selectedQuestion = db.Questions
                .Where(v => v.question_id == entityId).FirstOrDefault();
            return selectedQuestion;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Question Update(Question entity)
        {
            var selectedQuestion = db.Questions
              .Where(v => v.question_id == entity.question_id)
              .FirstOrDefault();

            if (selectedQuestion != null)
            {
                selectedQuestion.title = entity.title;
                selectedQuestion.type = entity.type;
                selectedQuestion.description = entity.description;
                selectedQuestion.score = entity.score;
                selectedQuestion.template_id = entity.template_id;
                selectedQuestion.updated_at = DateTime.Now;
                selectedQuestion.updated_by = entity.updated_by;

                db.Entry(selectedQuestion).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedQuestion;
        }
    }
}
