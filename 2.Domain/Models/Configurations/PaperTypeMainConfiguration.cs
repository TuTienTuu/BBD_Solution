using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class PaperTypeMainConfiguration : IEntityTypeConfiguration<PaperTypeMain>
    {
        public void Configure(IEntityTypeConfiguration<PaperTypeMain> builder)
        {

        }

        public void Configure(EntityTypeBuilder<PaperTypeMain> builder)
        {
            builder.ToTable("PaperTypeMains", "Paper");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.PaperTypeMainCode).IsRequired().HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.PaperTypeMainName).IsRequired().HasColumnType("NVARCHAR(250)");

        }

    }
}
