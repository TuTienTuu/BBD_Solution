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
    public class MaterialTypeConfiguration : IEntityTypeConfiguration<MateriaType>
    {
        public void Configure(IEntityTypeConfiguration<MateriaType> builder)
        {

        }

        public void Configure(EntityTypeBuilder<MateriaType> builder)
        {
            builder.ToTable("MaterialTypes", "Paper");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.Name).IsRequired().HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.Deleted).HasDefaultValue(DateTime.MinValue);
            builder.Property(x => x.Modified).HasDefaultValue(DateTime.MinValue);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

        }
    }
}
