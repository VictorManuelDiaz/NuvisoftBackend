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
    public class JobRepository : IBaseRepository<Job, Guid>
    {
        private NuvisoftDB db;
        public JobRepository(NuvisoftDB db)
        {
            this.db = db;
        }
        public Job Create(Job job)
        {
            job.job_id = Guid.NewGuid();
            job.created_by = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            job.updated_by = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            job.created_at = DateTime.Now;
            job.updated_at = DateTime.Now;
            db.Jobs.Add(job);
            return job;
        }

        public void Delete(Guid entityId)
        {
            var selectedJob = db.Jobs
              .Where(v => v.job_id == entityId).FirstOrDefault();

            if (selectedJob != null)
                db.Jobs.Remove(selectedJob);
        }

        public List<Job> GetAll()
        {
            return db.Jobs.Include(job => job.Template).ToList();
        }

        public Job GetById(Guid entityId)
        {
            var selectedJob = db.Jobs.Include(job => job.Template)
                .Where(v => v.job_id == entityId).FirstOrDefault();
            return selectedJob;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Job Update(Job entity)
        {
            var selectedJob = db.Jobs
              .Where(v => v.job_id == entity.job_id)
              .FirstOrDefault();

            if (selectedJob != null)
            {
                selectedJob.start = entity.start;
                selectedJob.end = entity.end;
                selectedJob.template_id = entity.template_id;
                selectedJob.updated_at = DateTime.Now;

                db.Entry(selectedJob).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedJob;
        }
    }
}
