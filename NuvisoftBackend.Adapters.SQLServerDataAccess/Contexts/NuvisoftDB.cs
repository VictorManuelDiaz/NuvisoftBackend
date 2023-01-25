using Microsoft.EntityFrameworkCore;
using NuvisoftBackend.Adapters.SQLServerDataAccess.Entities;
using NuvisoftBackend.Adapters.SQLServerDataAccess.Utils;
using NuvisoftBackend.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvisoftBackend.Adapters.SQLServerDataAccess.Contexts
{
    public class NuvisoftDB : DbContext
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ESubject());
            builder.ApplyConfiguration(new ETemplate());
            builder.ApplyConfiguration(new EQuestion());
            builder.ApplyConfiguration(new EAnswer());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(GlobalSetting.ConnectionString);
        }
    }
}
