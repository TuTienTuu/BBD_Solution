using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class CodeLevel1ManagementConfiguration : IEntityTypeConfiguration<CodeLevel1Management>
    {
        public void Configure(IEntityTypeConfiguration<CodeLevel1Management> builder)
        {

        }

        public void Configure(EntityTypeBuilder<CodeLevel1Management> builder)
        {
            builder.ToTable("CodeLevel1Managements", "dbo");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.CodeLevel1).IsRequired().HasColumnType("VARCHAR(3)");
            builder.Property(x => x.CodeLevel1Description).IsRequired().HasColumnType("NVARCHAR(50)");
            builder.Property(x => x.CodeLevel1Lenght).IsRequired();

        }
    }
}
