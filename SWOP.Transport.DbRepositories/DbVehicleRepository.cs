using SWOP.Transport.IRepositories;
using SWOP.Transport.Models;
using SWOP.Transport.Models.SearchCriterias;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWOP.Transport.DbRepositories
{
    public class DbVehicleRepository : DbEntityRepository<Vehicle>, IVehicleRepository
    {
        public DbVehicleRepository(TransportContext context) : base(context)
        {
        }

        public ICollection<Vehicle> Get(VehicleSearchCriteria criteria) => Query(criteria).ToList();

        public async Task<ICollection<Vehicle>> GetAsync(VehicleSearchCriteria criteria) => await Query(criteria).ToListAsync();

        private IQueryable<Vehicle> Query(VehicleSearchCriteria criteria)
        {
            IQueryable<Vehicle> results = entities;

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

            return results;
        }

    }
}
