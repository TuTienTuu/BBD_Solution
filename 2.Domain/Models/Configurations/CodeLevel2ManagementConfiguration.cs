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
    public class CodeLevel2ManagementConfiguration : IEntityTypeConfiguration<CodeLevel2Management>
    {
        public void Configure(IEntityTypeConfiguration<CodeLevel2Management> builder)
        {

        }

        public void Configure(EntityTypeBuilder<CodeLevel2Management> builder)
        {
            builder.ToTable("CodeLevel2Managements", "dbo");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.CodeLevel2).IsRequired().HasColumnType("VARCHAR(50)");
            builder.Property(x => x.CodeLevel1).IsRequired().HasColumnType("VARCHAR(3)");
            builder.Property(x => x.CodeLevel2Description).IsRequired().HasColumnType("NVARCHAR(50)");
            builder.Property(x => x.CodeLevel2Lenght).IsRequired();

        }
    }
}