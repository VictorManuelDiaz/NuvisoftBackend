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
    public class ESubjectSchedule : IEntityTypeConfiguration<SubjectSchedule>
    {
        public void Configure(EntityTypeBuilder<SubjectSchedule> builder)
        {
            builder.ToTable("atb_subject_schedule");

            builder.HasKey(v => v.subject_schedule_id);

            builder.HasOne(v => v.Schedule)
                .WithMany(v => v.SubjectSchedules);

            builder.HasOne(v => v.Subject)
                .WithMany(v => v.SubjectSchedules);
        }
    }
}
