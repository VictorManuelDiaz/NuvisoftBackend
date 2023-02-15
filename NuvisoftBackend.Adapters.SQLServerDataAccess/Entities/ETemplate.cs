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
    // Tabla Plantilla
    public class ETemplate : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
            builder.ToTable("tb_template");

            builder.HasKey(v => v.template_id);

            builder.HasOne(v => v.Subject)
                .WithMany(v => v.Templates);

            builder.HasMany(v => v.Questions)
                .WithOne(v => v.Template);

            builder.HasMany(v => v.Jobs)
                .WithOne(v => v.Template);
        }
    }
}
