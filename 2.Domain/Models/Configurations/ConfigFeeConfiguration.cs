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
    public class ConfigFeeConfiguration : IEntityTypeConfiguration<ConfigFee>
    {
        public void Configure(IEntityTypeConfiguration<ConfigFee> builder)
        {

        }

        public void Configure(EntityTypeBuilder<ConfigFee> builder)
        {
            builder.ToTable("ConfigFees", "Quotation");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.DepreciationFee).IsRequired().HasColumnType("Decimal(18,4)").HasDefaultValue(0);
            builder.Property(x => x.ElectricFeePerMachine).IsRequired().HasColumnType("Decimal(18,4)").HasDefaultValue(0);
            builder.Property(x => x.DepreciationFeePerMachineDay).IsRequired().HasColumnType("Decimal(18,4)").HasDefaultValue(0);
            builder.Property(x => x.DepreciationFeePerMachineHours).IsRequired().HasColumnType("Decimal(18,4)").HasDefaultValue(0);
            builder.Property(x => x.ElectricFee).IsRequired().HasColumnType("Decimal(18,4)").HasDefaultValue(0);
            builder.Property(x => x.ElectricFeePerMachine).IsRequired().HasColumnType("Decimal(18,4)").HasDefaultValue(0);
            builder.Property(x => x.MaintainFee).IsRequired().HasColumnType("Decimal(18,4)").HasDefaultValue(0);
            builder.Property(x => x.ManagerFee).IsRequired().HasColumnType("Decimal(18,4)").HasDefaultValue(0);
            builder.Property(x => x.ManagerFeePerMachine).IsRequired().HasColumnType("Decimal(18,4)").HasDefaultValue(0);
            builder.Property(x => x.WorkshopRentalFee).IsRequired().HasColumnType("Decimal(18,4)").HasDefaultValue(0);
            builder.Property(x => x.WorkshopRentalFeePerMachine).IsRequired().HasColumnType("Decimal(18,4)").HasDefaultValue(0);
            //builder.Property(x => x.Modified).IsRequired().HasColumnType("Datetime").HasDefaultValue(DateTime.MinValue);
            //builder.Property(x => x.Deleted).IsRequired().HasColumnType("Datetime").HasDefaultValue(DateTime.MinValue);
            //builder.Property(x => x.IsDeleted).IsRequired().HasColumnType("Bit").HasDefaultValue(0);
            builder.Property(x => x.Note).IsRequired(false).HasColumnType("NVARCHAR(max)");
        }
    }
}