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
    public class EGrade : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.ToTable("tb_grade");

            builder.HasKey(v => v.grade_id);

            builder.HasOne(v => v.Job)
                .WithMany(v => v.Grades);

            builder.HasOne(v => v.Student)
                .WithMany(v => v.Grades);
        }
    }
}
