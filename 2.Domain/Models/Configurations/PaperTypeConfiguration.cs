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
    public class PaperTypeConfiguration : IEntityTypeConfiguration<PaperType>
    {
        public void Configure(IEntityTypeConfiguration<PaperType> builder)
        {

        }

        public void Configure(EntityTypeBuilder<PaperType> builder)
        {
            builder.ToTable("PaperTypes", "Paper");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.PaperTypeCode).IsRequired().HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.PaperTypeName).IsRequired().HasColumnType("NVARCHAR(250)");

        }
    }
    
}
