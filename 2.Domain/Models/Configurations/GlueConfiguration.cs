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
    public class GlueConfiguration: IEntityTypeConfiguration<Glue>
    {
        public void Configure(IEntityTypeConfiguration<Glue> builder)
        {

        }

        public void Configure(EntityTypeBuilder<Glue> builder)
        {
            builder.ToTable("Glues", "Paper");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.GlueName).IsRequired().HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.GlueCode).IsRequired();

        }
    }
}
