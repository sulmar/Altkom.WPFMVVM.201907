using Bogus;
using SWOP.Transport.FakeRepositories.Fakers;
using SWOP.Transport.IRepositories;
using SWOP.Transport.Models;
using SWOP.Transport.Models.SearchCriterias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWOP.Transport.FakeRepositories
{
        
    public class FakeVehicleRepository : FakeEntityRepository<Vehicle>, IVehicleRepository
    {
        public FakeVehicleRepository(VehicleFaker faker) : base(faker)
        {
        }

        public void Add(Vehicle vehicle, Employee employee)
        {
            throw new NotImplementedException();
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
                //bool isHoliday1 = DateTime.Now.IsHoliday();

                //bool isHoliday = DateTimeHelper.IsHoliday(DateTime.Now);

                results = results.Where(p => p.PlateNumber.ContainsInvariant(criteria.PlateNumber));
            }

            if (criteria.Period.From.HasValue)
            {
                results = results.Where(p => p.CreatedAt >= criteria.Period.From);
            }

            if (criteria.Period.To.HasValue)
            {
                results = results.Where(p => p.CreatedAt <= criteria.Period.To);
            }

            // Task.Delay(TimeSpan.FromSeconds(5)).Wait();

            return results.ToList();
        }

        public Task<ICollection<Vehicle>> GetAsync(VehicleSearchCriteria criteria)
        {
            return Task.Run(() => Get(criteria));
        }
    }

    
}
