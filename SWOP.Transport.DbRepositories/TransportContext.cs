using SWOP.Transport.DbRepositories.Configurations;
using SWOP.Transport.DbRepositories.Conventions;
using SWOP.Transport.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWOP.Transport.DbRepositories
{
    public class TransportContext : DbContext        
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }


        public TransportContext(IDatabaseInitializer<TransportContext> initializer)
               : base("TransportConnection")
        {
            Database.SetInitializer(initializer);

            // Lazy Loading
            //this.Configuration.LazyLoadingEnabled = true;
            //this.Configuration.ProxyCreationEnabled = true;


            // this.Configuration.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Properties<DateTime>()
            //    .Configure(p => p.HasColumnType("datetime2"));

            //modelBuilder.Conventions.Add(new DateTime2Convention());
            modelBuilder.Conventions.Add<DateTime2Convention>();

            modelBuilder.Configurations.Add(new VehicleConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());

            


            base.OnModelCreating(modelBuilder);
        }
    }
}
