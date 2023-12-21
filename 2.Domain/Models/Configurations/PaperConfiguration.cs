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
    public class PaperConfiguration : IEntityTypeConfiguration<Paper>
    {
        public void Configure(IEntityTypeConfiguration<PaperTypeMain> builder)
        {

        }

        public void Configure(EntityTypeBuilder<Paper> builder)
        {
            builder.ToTable("Papers", "Paper");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.PaperTypeCode).IsRequired().HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.PaperTypeName).IsRequired().HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.Purpose).IsRequired(false).HasColumnType("NVARCHAR(max)");
        }
    }
}
