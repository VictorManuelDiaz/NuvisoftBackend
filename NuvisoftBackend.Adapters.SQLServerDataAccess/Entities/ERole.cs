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
    public class ERole : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("tb_role");
            builder.HasKey(v => v.role_id);

            builder.HasMany(v => v.Privileges)
                .WithOne(v => v.Role);
        }
    }
}
