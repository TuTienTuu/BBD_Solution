using Data.Configurations;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF
{
    public class DatabaseContext : IdentityDbContext<Employee,EmployeeRole,Guid>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GlueConfiguration());
            modelBuilder.ApplyConfiguration(new SoleConfiguration());
            modelBuilder.ApplyConfiguration(new PaperTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PaperTypeMainConfiguration());
            modelBuilder.ApplyConfiguration(new PaperConfiguration());
            modelBuilder.ApplyConfiguration(new UpdateDataPaperTrackingConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialConfiguration());
            modelBuilder.ApplyConfiguration(new ConfigFeeConfiguration());
            modelBuilder.ApplyConfiguration(new MachineConfigConfiguration());

            modelBuilder.ApplyConfiguration(new UnitPriceConfiguration());

            modelBuilder.ApplyConfiguration(new CodeLevel1ManagementConfiguration());
            modelBuilder.ApplyConfiguration(new CodeLevel2ManagementConfiguration());

            modelBuilder.ApplyConfiguration(new STA0010_Material_MasterConfiguration());
            modelBuilder.ApplyConfiguration(new STA0020_Material_Supplier_LOTNOConfiguration());
            modelBuilder.ApplyConfiguration(new STA0030_Material_Supplier_RAWNOConfiguration());
            modelBuilder.ApplyConfiguration(new STA1010_Material_IN_OUT_LogConfiguration());


            modelBuilder.ApplyConfiguration(new STB0010_Material_Export_TrackingConfiguration());
            

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("EmployeeClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("EmployeeRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("EmployeeLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("EmployeeRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("EmployeeUserTokens").HasKey(x => x.UserId);
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FunctionResult>(e => e.HasNoKey());
        }

        public DbSet<Glue> Glues { get; set; }
        public DbSet<Sole> Soles { get; set; }
        public DbSet<PaperType> PaperTypes { get; set; }
        public DbSet<PaperTypeMain> PaperTypeMains { get; set; }
        public DbSet<Paper> Papers { get; set; }
        public DbSet<UpdateDataPaperTracking> UpdateDataPaperTrackings { get; set; }
        public DbSet<MateriaType> MaterialTypes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<ConfigFee> ConfigFees { get; set; }
        public DbSet<MachineConfig> MachineConfigs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }

        public DbSet<CodeLevel1Management> CodeLevel1Managements { get; set; }
        public DbSet<CodeLevel2Management> CodeLevel2Managements { get; set; }

        public DbSet<STA0010_Material_Master> STA0010_Material_Masters { get; set; }
        public DbSet<STA0020_Material_Supplier_LOTNO> STA0020_Material_Supplier_LOTNOs { get; set; }

        public DbSet<STB0010_BARCODE_Printing_Log> STB0010_Material_Export_Trackings { get; set; }
        public DbSet<STA0030_Material_Supplier_RAWNO> STA0030_Material_Supplier_RAWNOs { get; set; }
        public DbSet<STA1010_Material_IN_OUT_Log> STA1010_Material_IN_OUT_Logs { get; set; }

        public DbSet<UnitPrice> UnitPrices { get; set; }

        //Function Result
        public DbSet<FunctionResult> FunctionResults { get; set; }


        
    }
}
