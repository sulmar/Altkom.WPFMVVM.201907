using Bogus;
using SWOP.Transport.IRepositories;
using SWOP.Transport.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SWOP.Transport.FakeRepositories
{
    public class FakeEntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected ICollection<TEntity> entities;

        private Faker<TEntity> faker;

        public FakeEntityRepository(Faker<TEntity> faker)
        {
            this.faker = faker;

            entities = faker.Generate(50);
        }

        public void Add(TEntity entity)
        {
            entities.Add(entity);
        }

        public ICollection<TEntity> Get()
        {
            return entities;
        }

        public TEntity Get(int id)
        {
            TEntity entity = entities.SingleOrDefault(p => p.Id == id);

            return entity;
        }

        public void Remove(int id)
        {
            entities.Remove(Get(id));
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }

    //public class FakeVehicleRepository : IVehicleRepository
    //{
    //    private ICollection<Vehicle> vehicles;

    //    private VehicleFaker vehicleFaker;

    //    public FakeVehicleRepository()
    //    {
    //        vehicleFaker = new VehicleFaker();

    //        vehicles = vehicleFaker.Generate(100);
    //    }

    //    public void Add(Vehicle vehicle)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public ICollection<Vehicle> Get()
    //    {
    //        return vehicles; 
    //    }

    //    public Vehicle Get(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Remove(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Update(Vehicle vehicle)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
