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
    public class DbVehicleRepository : IVehicleRepository
    {
        private readonly TransportContext context;

        public DbVehicleRepository(TransportContext context)
        {
            this.context = context;
        }

        public void Add(Vehicle entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<Vehicle> Get(VehicleSearchCriteria criteria)
        {
            return context.Vehicles.ToList();
        }

        public ICollection<Vehicle> Get()
        {
            return context.Vehicles.ToList();
        }

        public Vehicle Get(int id)
        {
            return context.Vehicles.Find(id);
        }

        public async Task<ICollection<Vehicle>> GetAsync(VehicleSearchCriteria criteria)
        {
            // using System.Data.Entity;
            return await context.Vehicles.ToListAsync();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Vehicle entity)
        {
            throw new NotImplementedException();
        }
    }
}
