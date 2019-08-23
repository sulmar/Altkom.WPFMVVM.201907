using SWOP.Transport.DbRepositories.Configurations;
using SWOP.Transport.DbRepositories.Conventions;
using SWOP.Transport.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
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

        public ObjectContext ObjectContext => ((IObjectContextAdapter)this).ObjectContext;

        public TransportContext()
            : base("TransportConnection")
        {
            this.Database.Log = Console.WriteLine;

            GetDocumentation();
        }

        private void GetDocumentation()
        {
            var workspace = ObjectContext.MetadataWorkspace;

            var tables = workspace.GetItems<EntityType>(DataSpace.CSpace);

            foreach (var table in tables)
            {
                Console.WriteLine(table.Name);

                foreach (var property in table.Properties)
                {
                    Console.WriteLine($"{property.Name}");
                }

            }
        }


        public TransportContext(IDatabaseInitializer<TransportContext> initializer)
               : this()
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
