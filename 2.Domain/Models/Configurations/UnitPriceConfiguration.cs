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
    public class UnitPriceConfiguration : IEntityTypeConfiguration<UnitPrice>
    {
        public void Configure(IEntityTypeConfiguration<UnitPrice> builder)
        {

        }

        public void Configure(EntityTypeBuilder<UnitPrice> builder)
        {
            builder.ToTable("UnitPrices", "Quotation");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.Characteristic).IsRequired().HasColumnType("NVARCHAR(250)");
            //builder.Property(x => x.Price).IsRequired().HasColumnType("DECINMAL(18,2)");
            builder.Property(x => x.Note).IsRequired().HasColumnType("NVARCHAR(max)");
            builder.Property(x => x.Spec).IsRequired().HasColumnType("NVARCHAR(250)");
            //bilder.Property(x => x.MaterialName).IsRequired().HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.Unit).IsRequired().HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.Deleted).HasDefaultValue(DateTime.MinValue);
            builder.Property(x => x.Modified).HasDefaultValue(DateTime.MinValue);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

        }
    }
}