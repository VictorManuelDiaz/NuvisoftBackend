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
    public class EGroup : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("tb_group");

            builder.HasKey(v => v.group_id);

            builder.HasMany(v => v.GroupSubject)
                .WithOne(v => v.Group);

            builder.HasOne(v => v.School)
                .WithMany(v => v.Groups);

            builder.HasMany(v => v.GroupStudent)
               .WithOne(v => v.Group);
        }
    }
}
