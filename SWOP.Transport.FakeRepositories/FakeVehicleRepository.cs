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
            IEnumerable<Vehicle> results = entities;

            //results = results
            //    .Where(p => !string.IsNullOrEmpty(criteria.Brand) && p.Brand == criteria.Brand)
            //    .Where(p => !string.IsNullOrEmpty(criteria.Model) && p.Model == criteria.Model)
            //    .ToList();

            if (!string.IsNullOrEmpty(criteria.Brand))
            {
                results = results.Where(p => p.Brand == criteria.Brand);
            }

            if (!string.IsNullOrEmpty(criteria.Model))
            {
                results = results.Where(p => p.Model == criteria.Model);
            }

            if (!string.IsNullOrEmpty(criteria.PlateNumber))
            {
                results = results.Where(p => p.PlateNumber.Contains(criteria.PlateNumber));
            }

            if (criteria.Period.From.HasValue)
            {
                results = results.Where(p => p.CreatedAt >= criteria.Period.From);
            }

            if (criteria.Period.To.HasValue)
            {
                results = results.Where(p => p.CreatedAt <= criteria.Period.To);
            }

            return results.ToList();
        }


      
    }

    
}
