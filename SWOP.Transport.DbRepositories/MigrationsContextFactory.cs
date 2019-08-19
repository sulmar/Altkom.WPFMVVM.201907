using SWOP.Transport.DbRepositories.Initializers;
using SWOP.Transport.FakeRepositories.Fakers;
using System.Data.Entity.Infrastructure;

namespace SWOP.Transport.DbRepositories
{
    public class MigrationsContextFactory : IDbContextFactory<TransportContext>
    {
        public TransportContext Create()
        {
            return new TransportContext(new TransportDbInitializer(
                    new VehicleFaker(),
                    new PolicemanFaker(),
                    new CivilFaker()
                    ));
        }
    }
}
