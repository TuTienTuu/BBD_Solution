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
    public class STA0030_Material_Supplier_RAWNOConfiguration : IEntityTypeConfiguration<STA0030_Material_Supplier_RAWNO>
    {
        public void Configure(IEntityTypeConfiguration<STA0030_Material_Supplier_RAWNO> builder)
        {

        }

        public void Configure(EntityTypeBuilder<STA0030_Material_Supplier_RAWNO> builder)
        {
            builder.ToTable("STA0030_Material_Supplier_RAWNOs", "BDST");

            builder.HasKey(x => x.ID);

            //builder.Property(x => x.RAWNO).IsRequired().HasColumnType("CHAR(14)");
            builder.Property(x => x.RawNo).IsRequired().HasColumnType("CHAR(14)");
            //builder.Property(x => x.LOTNO).IsRequired().HasColumnType("CHAR(11)");
            builder.Property(x => x.LotNo).IsRequired().HasColumnType("CHAR(11)");
            //builder.Property(x => x.MATCD).IsRequired().HasColumnType("NVARCHAR(5)");
            builder.Property(x => x.MatCD).IsRequired().HasColumnType("NVARCHAR(5)");
            builder.Property(x => x.MaterialCode).IsRequired().HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.MaterialName).IsRequired(false).HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.Supplier).IsRequired().HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.Remark).IsRequired(false).HasColumnType("NVARCHAR(max)");
            
            //builder.Property(x => x.UNITQTY).IsRequired().HasColumnType("Float");
            builder.Property(x => x.UnitQuantity).IsRequired().HasColumnType("Float");
            builder.Property(x => x.Unit).IsRequired().HasColumnType("NVARCHAR(250)");
           
            //builder.Property(x => x.Deleted).HasDefaultValue(DateTime.MinValue);
            //builder.Property(x => x.Modified).HasDefaultValue(DateTime.MinValue);
            //builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            //builder.Property(x => x.Price).IsRequired().HasColumnType("Int");

            builder.Property(x => x.Size).IsRequired(false).HasColumnType("NVARCHAR(Max)");
            //builder.Property(x => x.Sup_LOT).IsRequired(false).HasColumnType("NVARCHAR(25)");
            //builder.Property(x => x.PROD_DAT).IsRequired(false).HasColumnType("NVARCHAR(8)");
            //builder.Property(x => x.IMPORT_DAT).IsRequired(false).HasColumnType("NVARCHAR(14)");
            //builder.Property(x => x.TEST_DAT).IsRequired(false).HasColumnType("NVARCHAR(14)");
            //builder.Property(x => x.TEST_RESULT).IsRequired(false).HasColumnType("CHAR(1)");
            //builder.Property(x => x.EXPIRED_DAT).IsRequired(false).HasColumnType("NVARCHAR(14)");
            //builder.Property(x => x.EXPORT_DAT).IsRequired(false).HasColumnType("NVARCHAR(14)");
            //builder.Property(x => x.USE_DAT).IsRequired().HasColumnType("NVARCHAR(14)");
            
            builder.Property(x => x.SupLOT).IsRequired(false).HasColumnType("NVARCHAR(25)");
            builder.Property(x => x.ProductDate).IsRequired(false).HasColumnType("datetime2");
            builder.Property(x => x.InStockDate).IsRequired(false).HasColumnType("datetime2");
            builder.Property(x => x.TestDate).IsRequired(false).HasColumnType("datetime2");
            builder.Property(x => x.TestResult).IsRequired(false).HasColumnType("CHAR(1)");
            builder.Property(x => x.ExpiredDate).IsRequired(false).HasColumnType("datetime2");
            builder.Property(x => x.OutStockDate).IsRequired(false).HasColumnType("datetime2");
            builder.Property(x => x.UseDate).IsRequired(false).HasColumnType("datetime2");
          


        }
    }
}