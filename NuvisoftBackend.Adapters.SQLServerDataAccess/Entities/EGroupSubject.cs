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
    public class EGroupSubject : IEntityTypeConfiguration<GroupSubject>
    {
        public void Configure(EntityTypeBuilder<GroupSubject> builder)
        {
            builder.ToTable("atb_group_subject");
            builder.HasKey(v => v.group_subject_id);

            builder.HasOne(v => v.Group)
                .WithMany(v => v.GroupSubject);

            builder.HasOne(v => v.Subject)
                .WithMany(v => v.GroupSubject);

        }
    }
}
