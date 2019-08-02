using SWOP.Transport.Models;
using SWOP.Transport.Models.SearchCriterias;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWOP.Transport.IRepositories
{
    //public interface IVehicleRepository
    //{
    //    ICollection<Vehicle> Get();
    //    Vehicle Get(int id);
    //    void Add(Vehicle vehicle);
    //    void Update(Vehicle vehicle);
    //    void Remove(int id);
    //}

    public interface IVehicleRepository : IEntityRepository<Vehicle>
    {
        ICollection<Vehicle> Get(VehicleSearchCriteria criteria);
        Task<ICollection<Vehicle>> GetAsync(VehicleSearchCriteria criteria);
    }

    public interface IEntityRepository<TEntity>
    {
        ICollection<TEntity> Get();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);
    }
}
