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
    public class STA1010_Material_IN_OUT_LogConfiguration : IEntityTypeConfiguration<STA1010_Material_IN_OUT_Log>
    {
        public void Configure(IEntityTypeConfiguration<STA1010_Material_IN_OUT_Log> builder)
        {

        }

        public void Configure(EntityTypeBuilder<STA1010_Material_IN_OUT_Log> builder)
        {
            builder.ToTable("STA1010_Material_IN_OUT_Logs", "BDST");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.StockCD).IsRequired().HasColumnType("CHAR(4)");
            builder.Property(x => x.Action).IsRequired().HasColumnType("CHAR(1)");
            builder.Property(x => x.StatusCheck).IsRequired().HasColumnType("CHAR(3)");
            builder.Property(x => x.RawNo).IsRequired().HasColumnType("CHAR(14)");
            builder.Property(x => x.FIFOYN).IsRequired(false).HasColumnType("CHAR(1)");
            builder.Property(x => x.EmployeeID).IsRequired().HasColumnType("CHAR(6)");
            builder.Property(x => x.WorkDateTime).IsRequired().HasColumnType("datetime2");
            builder.Property(x => x.Remark).IsRequired(false).HasColumnType("NVARCHAR(max)");

            builder.Property(x => x.Quantity).IsRequired().HasColumnType("Float");
           
        }
    }
}
