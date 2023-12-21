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
    public class STA0010_Material_MasterConfiguration : IEntityTypeConfiguration<STA0010_Material_Master>
    {
        public void Configure(IEntityTypeConfiguration<STA0010_Material_Master> builder)
        {

        }

        public void Configure(EntityTypeBuilder<STA0010_Material_Master> builder)
        {
            builder.ToTable("STA0010_Material_Masters", "BDST");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.MATCD).IsRequired().HasColumnType("NVARCHAR(5)");
            builder.Property(x => x.MATGROUPCD).IsRequired().HasColumnType("CHAR(1)");
         
            builder.Property(x => x.Note).IsRequired(false).HasColumnType("NVARCHAR(max)");
            builder.Property(x => x.MaterialCode).IsRequired().HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.MaterialName).IsRequired(false).HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.Unit).IsRequired(false).HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.UnitQty).IsRequired().HasColumnType("Int");
            builder.Property(x => x.Deleted).HasDefaultValue(DateTime.MinValue);
            builder.Property(x => x.Modified).HasDefaultValue(DateTime.MinValue);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

        }
    }
}
