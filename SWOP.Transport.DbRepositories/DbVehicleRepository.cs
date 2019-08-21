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

        public async Task<ICollection<Vehicle>> GetAsync(VehicleSearchCriteria criteria) => await Query(criteria).AsNoTracking().ToListAsync();

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

            results = results
                .OrderBy(p => p.Id);

            /* eager loading
             
            results = results
                .Include(p => p.Owner); 

            */

            return results;
        }

        public override void Update(Vehicle entity)
        {
            Console.WriteLine(context.Entry(entity).State);
            
            context.Entry(entity).State = EntityState.Modified;

            context.Entry(entity.Owner).State = EntityState.Unchanged;

            var entries = context.ChangeTracker.Entries();

            context.SaveChanges();

            Console.WriteLine(context.Entry(entity).State);


            // base.Update(entity);
        }

        public override Vehicle Get(int id)
        {
            Vehicle vehicle = base.Get(id);

            // explicit loading

            // discret
            context.Entry(vehicle).Reference(p => p.Owner).Load();

            // collection
            // context.Entry(vehicle).Collection(p => p.Deadlines).Load();

            // filter
            context.Entry(vehicle)
                .Collection(p => p.Deadlines)
                .Query()
                .Where(p=>p.Date < DateTime.Now)
                .Load();

            // return base.Get(id);

            return vehicle;
        }

    }
}
