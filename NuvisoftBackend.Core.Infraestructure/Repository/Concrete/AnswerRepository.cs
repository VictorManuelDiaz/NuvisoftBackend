using Microsoft.EntityFrameworkCore;
using NuvisoftBackend.Adapters.SQLServerDataAccess.Contexts;
using NuvisoftBackend.Adapters.SQLServerDataAccess.Entities;
using NuvisoftBackend.Core.Domain.Models;
using NuvisoftBackend.Core.Infraestructure.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvisoftBackend.Core.Infraestructure.Repository.Concrete
{
    public class AnswerRepository : IBaseRepository<Answer, Guid>
    {
        private NuvisoftDB db;
        public AnswerRepository(NuvisoftDB db)
        {
            this.db = db;
        }

        public Answer Create(Answer answer)
        {
            answer.answer_id = Guid.NewGuid();
            answer.created_by = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            answer.updated_by = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            answer.created_at = DateTime.Now;
            answer.updated_at = DateTime.Now;
            db.Answers.Add(answer);
            return answer;
        }

        public void Delete(Guid entityId)
        {
            var selectedAnswer = db.Answers
              .Where(v => v.answer_id == entityId).FirstOrDefault();

            if (selectedAnswer != null)
                db.Answers.Remove(selectedAnswer);
        }

        public List<Answer> GetAll()
        {
            return db.Answers.Include(answer => answer.Question).ToList();
        }

        public Answer GetById(Guid entityId)
        {
            var selectedAnswer = db.Answers.Include(answer => answer.Question)
                .Where(v => v.answer_id == entityId).FirstOrDefault();
            return selectedAnswer;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Answer Update(Answer entity)
        {
            var selectedAnswer = db.Answers
              .Where(v => v.answer_id == entity.answer_id)
              .FirstOrDefault();

            if (selectedAnswer != null)
            {
                selectedAnswer.description = entity.description;
                selectedAnswer.is_correct = entity.is_correct;
                selectedAnswer.question_id = entity.question_id;
                selectedAnswer.updated_at = DateTime.Now;

                db.Entry(selectedAnswer).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedAnswer;
        }
    }
}
