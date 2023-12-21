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
    public class MachineConfigConfiguration : IEntityTypeConfiguration<MachineConfig>
    {
        public void Configure(IEntityTypeConfiguration<MachineConfig> builder)
        {

        }

        public void Configure(EntityTypeBuilder<MachineConfig> builder)
        {
            builder.ToTable("MachineConfigs", "Quotation");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.WhiteCarry).IsRequired().HasColumnType("int").HasDefaultValue(0);
            builder.Property(x => x.KWPerHour).IsRequired().HasColumnType("Decimal(18,4)").HasDefaultValue(0);
            builder.Property(x => x.Power).IsRequired().HasColumnType("Decimal(18,4)").HasDefaultValue(0);
            builder.Property(x => x.Target).IsRequired().HasColumnType("int").HasDefaultValue(0);
            builder.Property(x => x.Change).IsRequired().HasColumnType("Decimal(18,4)").HasDefaultValue(0);
            builder.Property(x => x.ChangeRoll).IsRequired().HasColumnType("int").HasDefaultValue(0);
            builder.Property(x => x.ChangeRoll_H).IsRequired().HasColumnType("Decimal(18,4)").HasDefaultValue(0);
            builder.Property(x => x.ChangeSpec).IsRequired().HasColumnType("int").HasDefaultValue(0);
            builder.Property(x => x.ChangeSpec_H).IsRequired().HasColumnType("Decimal(18,4)").HasDefaultValue(0);
            builder.Property(x => x.Color).IsRequired().HasColumnType("int").HasDefaultValue(0);
            builder.Property(x => x.Compensation).IsRequired().HasColumnType("int").HasDefaultValue(0);
            builder.Property(x => x.CostAllocationPercent).IsRequired().HasColumnType("int").HasDefaultValue(0);
            builder.Property(x => x.ElectricPrice).IsRequired().HasColumnType("Decimal(18,4)").HasDefaultValue(0);
            builder.Property(x => x.HourlySalary).IsRequired().HasColumnType("Decimal(18,4)").HasDefaultValue(0);
            builder.Property(x => x.OperatorSalary_1).IsRequired().HasColumnType("Decimal(18,4)").HasDefaultValue(0);
            builder.Property(x => x.OperatorSalary_2).IsRequired().HasColumnType("Decimal(18,4)").HasDefaultValue(0);
            builder.Property(x => x.OperatorNumber).IsRequired().HasColumnType("int").HasDefaultValue(0);
            builder.Property(x => x.Risk).IsRequired().HasColumnType("int").HasDefaultValue(0);
            //builder.Property(x => x.Modified).IsRequired().HasColumnType("Datetime").HasDefaultValue(DateTime.MinValue);
            //builder.Property(x => x.Deleted).IsRequired().HasColumnType("Datetime").HasDefaultValue(DateTime.MinValue);
            //builder.Property(x => x.IsDeleted).IsRequired().HasColumnType("Bit").HasDefaultValue(0);
            builder.Property(x => x.Note).IsRequired(false).HasColumnType("NVARCHAR(max)");
            builder.Property(x => x.MachineName).IsRequired(false).HasColumnType("NVARCHAR(50)");
        }
    }
}