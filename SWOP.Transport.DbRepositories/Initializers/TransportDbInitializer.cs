using SWOP.Transport.FakeRepositories.Fakers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWOP.Transport.DbRepositories.Initializers
{
    public class TransportDbInitializer : CreateDatabaseIfNotExists<TransportContext>
    {
        private readonly VehicleFaker vehicleFaker;
        private readonly PolicemanFaker policemanFaker;
        private readonly CivilFaker civilFaker;

        public TransportDbInitializer(VehicleFaker vehicleFaker, PolicemanFaker policemanFaker, CivilFaker civilFaker)
        {
            this.vehicleFaker = vehicleFaker;
            this.policemanFaker = policemanFaker;
            this.civilFaker = civilFaker;
        }

        protected override void Seed(TransportContext context)
        {
            context.Vehicles.AddRange(vehicleFaker.Generate(1000));
            context.Employees.AddRange(policemanFaker.Generate(100));
            context.Employees.AddRange(civilFaker.Generate(30));

            base.Seed(context);
        }

    }
}
