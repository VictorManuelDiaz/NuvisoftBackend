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
    public class EPrivilege : IEntityTypeConfiguration<Privilege>
    {
        public void Configure(EntityTypeBuilder<Privilege> builder)
        {
            builder.ToTable("atb_privilege");
            builder.HasKey(v => v.privilege_id);

            builder.HasMany(v => v.PrivilegesSubject)
                .WithOne(v => v.Privilege);

            builder.HasOne(v => v.Role)
               .WithMany(v => v.Privileges);

            builder.HasOne(v => v.User)
               .WithMany(v => v.Privileges);
        }
    }
}
