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
    public class STB0010_Material_Export_TrackingConfiguration : IEntityTypeConfiguration<STB0010_BARCODE_Printing_Log>
    {
        public void Configure(IEntityTypeConfiguration<STB0010_BARCODE_Printing_Log> builder)
        {

        }

        public void Configure(EntityTypeBuilder<STB0010_BARCODE_Printing_Log> builder)
        {
            builder.ToTable("STB0010_Material_Export_Trackings", "BDST");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.LOTNO).IsRequired().HasColumnType("CHAR(11)");
            builder.Property(x => x.MATCD).IsRequired().HasColumnType("CHAR(5)");
            builder.Property(x => x.STRNO).IsRequired().HasColumnType("INT");
            builder.Property(x => x.ENDNO).IsRequired().HasColumnType("INT");
            builder.Property(x => x.STA0020_Material_Supplier_LotnoID).IsRequired().HasColumnType("INT");

            builder.Property(x => x.MaterialCode).IsRequired().HasColumnType("NVARCHAR(250)");

            //builder.Property(x => x.Deleted).HasDefaultValue(DateTime.MinValue);
            //builder.Property(x => x.Modified).HasDefaultValue(DateTime.MinValue);
            //builder.Property(x => x.IsDeleted).HasDefaultValue(false);

        }
    }
}