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
    public class EPrivilegeSubject : IEntityTypeConfiguration<PrivilegeSubject>
    {
        public void Configure(EntityTypeBuilder<PrivilegeSubject> builder)
        {
            builder.ToTable("atb_privilege_subject");
            builder.HasKey(v => v.privilege_subject_id);

            builder.HasOne(v => v.Privilege)
                .WithMany(v => v.PrivilegesSubject);

            builder.HasOne(v => v.Subject)
                .WithMany(v => v.PrivilegesSubject);

        }
    }
}
