using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NuvisoftBackend.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvisoftBackend.Adapters.SQLServerDataAccess.Entities
{
    // Tabla Asignatura
    public class ESubject : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("tb_subject");

            builder.HasKey(v => v.subject_id);

            builder.HasMany(v => v.Templates)
                .WithOne(v => v.Subject);

            builder.HasMany(v => v.PrivilegesSubject)
               .WithOne(v => v.Subject);

            builder.HasMany(v => v.SubjectSchedules)
                .WithOne(v => v.Subject);

            builder.HasMany(v => v.GroupSubject)
               .WithOne(v => v.Subject);
        }
    }
}
