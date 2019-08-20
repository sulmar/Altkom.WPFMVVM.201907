using SWOP.Transport.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWOP.Transport.DbRepositories.Configurations
{
    class VehicleConfiguration : EntityTypeConfiguration<Vehicle>
    {
        public VehicleConfiguration()
        {
            // ToTable("Pojazdy");

            HasKey(p => p.Id);
            

            Property(p => p.Model)
                .HasMaxLength(50);

            Property(p => p.Brand)
                .HasMaxLength(50);

            Property(p => p.PlateNumber)
                .HasMaxLength(8)
                .IsRequired()
                .IsUnicode(true);

            //Property(p => p.CreatedAt)
            //    .HasColumnType("datetime2");
        }
    }
}
