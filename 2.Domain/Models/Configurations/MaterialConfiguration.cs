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
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(IEntityTypeConfiguration<Material> builder)
        {

        }

        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.ToTable("Materials", "Paper");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.Supplier).IsRequired().HasColumnType("NVARCHAR(250)");
            //builder.Property(x => x.Price).IsRequired().HasColumnType("DECINMAL(18,2)");
            builder.Property(x => x.Note).IsRequired().HasColumnType("NVARCHAR(max)");
            builder.Property(x => x.MaterialCode).IsRequired().HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.MaterialName).IsRequired().HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.Unit).IsRequired().HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.Deleted).HasDefaultValue(DateTime.MinValue);
            builder.Property(x => x.Modified).HasDefaultValue(DateTime.MinValue);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

        }
    }
}