using SWOP.Transport.DbRepositories.Configurations;
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



        public TransportContext(IDatabaseInitializer<TransportContext> initializer)
               : base("TransportConnection")
        {
            Database.SetInitializer(initializer);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VehicleConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
