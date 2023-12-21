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
    public class STA0020_Material_Supplier_LOTNOConfiguration : IEntityTypeConfiguration<STA0020_Material_Supplier_LOTNO>
    {
        public void Configure(IEntityTypeConfiguration<STA0020_Material_Supplier_LOTNO> builder)
        {

        }

        public void Configure(EntityTypeBuilder<STA0020_Material_Supplier_LOTNO> builder)
        {
            builder.ToTable("STA0020_Material_Supplier_LOTNOs", "BDST");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.LotNo).IsRequired().HasColumnType("CHAR(11)");
            builder.Property(x => x.MatCD).IsRequired().HasColumnType("NVARCHAR(5)");
            builder.Property(x => x.Supplier).IsRequired().HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.SupLOT).IsRequired().HasColumnType("NVARCHAR(25)");
            builder.Property(x => x.UnitQuantity).IsRequired().HasColumnType("Float");
            builder.Property(x => x.ProductDate).IsRequired().HasColumnType("datetime2");
            builder.Property(x => x.ImportDate).IsRequired().HasColumnType("datetime2");
            builder.Property(x => x.TestDate).IsRequired().HasColumnType("datetime2");
            builder.Property(x => x.TestResult).IsRequired().HasColumnType("CHAR(1)");
            builder.Property(x => x.ExpiredDate).IsRequired().HasColumnType("datetime2");

            
            builder.Property(x => x.MaterialCode).IsRequired().HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.MaterialName).IsRequired().HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.Note).IsRequired(false).HasColumnType("NVARCHAR(max)");
            //builder.Property(x => x.Price).IsRequired().HasColumnType("Int");
            builder.Property(x => x.Unit).IsRequired().HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.Size).IsRequired().HasColumnType("NVARCHAR(Max)");
            
            builder.Property(x => x.Deleted).HasDefaultValue(DateTime.MinValue);
            builder.Property(x => x.Modified).HasDefaultValue(DateTime.MinValue);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

        }
    }
}