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
    public class EGroupStudent : IEntityTypeConfiguration<GroupStudent>
    {
        public void Configure(EntityTypeBuilder<GroupStudent> builder)
        {
            builder.ToTable("atb_group_student");
            builder.HasKey(v => v.group_student_id);

            builder.HasOne(v => v.Group)
                .WithMany(v => v.GroupStudent);

            builder.HasOne(v => v.Student)
                .WithMany(v => v.GroupStudent).OnDelete(DeleteBehavior.ClientSetNull);


        }
    }
}
