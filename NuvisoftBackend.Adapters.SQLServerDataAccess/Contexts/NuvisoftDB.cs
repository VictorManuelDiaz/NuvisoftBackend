using Microsoft.EntityFrameworkCore;
using NuvisoftBackend.Adapters.SQLServerDataAccess.Entities;
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
        public DbSet<Job> Jobs { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<User> Users { get; set; }

        public NuvisoftDB() : base()
        {
        }

        public NuvisoftDB(DbContextOptions<NuvisoftDB> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ESubject());
            builder.ApplyConfiguration(new ETemplate());
            builder.ApplyConfiguration(new EQuestion());
            builder.ApplyConfiguration(new EAnswer());
            builder.ApplyConfiguration(new EJob());
            builder.ApplyConfiguration(new ESchool());
            builder.ApplyConfiguration(new EUser());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=VMDS\\SQLEXPRESS;Initial Catalog=Nuvisoft;Integrated Security=True;");
            }
        }
    }
}
