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
    public class SoleConfiguration : IEntityTypeConfiguration<Sole>
    {
        public void Configure(IEntityTypeConfiguration<Sole> builder)
        {

        }

        public void Configure(EntityTypeBuilder<Sole> builder)
        {
            builder.ToTable("Soles", "Paper");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.SoleCode).IsRequired().HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.SoleInfomation).IsRequired().HasColumnType("NVARCHAR(250)");

        }
    }
}
