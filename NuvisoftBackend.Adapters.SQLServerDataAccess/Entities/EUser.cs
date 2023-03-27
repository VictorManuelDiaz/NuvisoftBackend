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
    public class EUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tb_user");

            builder.HasKey(v => v.user_id);
            builder.HasOne(v => v.School)
                .WithMany(v => v.Users);

            builder.HasMany(v => v.Privileges)
                .WithOne(v => v.User);

            builder.HasMany(v => v.Grades)
                .WithOne(v => v.Student);
        }
    }
}
