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
    public class UpdateDataPaperTrackingConfiguration: IEntityTypeConfiguration<UpdateDataPaperTracking>
    {
        public void Configure(IEntityTypeConfiguration<UpdateDataPaperTracking> builder)
        {

        }

        public void Configure(EntityTypeBuilder<UpdateDataPaperTracking> builder)
        {
            builder.ToTable("UpdateDataPaperTrackings", "Paper");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.TableName).IsRequired().HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.UpdateBy).IsRequired().HasColumnType("NVARCHAR(250)");

        }

    }
}
