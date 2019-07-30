using Bogus;
using SWOP.Transport.FakeRepositories.Fakers;
using SWOP.Transport.IRepositories;
using SWOP.Transport.Models;
using SWOP.Transport.Models.SearchCriterias;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SWOP.Transport.FakeRepositories
{

    public class FakeVehicleRepository : FakeEntityRepository<Vehicle>, IVehicleRepository
    {
        public FakeVehicleRepository(VehicleFaker faker) : base(faker)
        {
        }

        public ICollection<Vehicle> Get(VehicleSearchCriteria criteria)
        {
            throw new NotImplementedException();
        }
    }

    
}
