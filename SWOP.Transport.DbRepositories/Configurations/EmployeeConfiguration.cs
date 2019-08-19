using SWOP.Transport.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWOP.Transport.DbRepositories.Configurations
{
    class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            Property(p => p.FirstName)
                .HasMaxLength(20);

            Property(p => p.LastName)
                .HasMaxLength(32)
                .IsRequired();

            Property(p => p.Email)
                .HasMaxLength(255);

            Property(p => p.CellPhone)
                .HasMaxLength(9);

            HasIndex(p => p.Email)                
                .IsUnique();

        }
    }
}
