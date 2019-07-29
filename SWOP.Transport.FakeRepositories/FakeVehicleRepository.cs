using SWOP.Transport.FakeRepositories.Fakers;
using SWOP.Transport.IRepositories;
using SWOP.Transport.Models;
using System;
using System.Collections.Generic;

namespace SWOP.Transport.FakeRepositories
{
    public class FakeVehicleRepository : IVehicleRepository
    {
        private ICollection<Vehicle> vehicles;

        private VehicleFaker vehicleFaker;

        public FakeVehicleRepository()
        {
            vehicleFaker = new VehicleFaker();

            vehicles = vehicleFaker.Generate(100);
        }

        public void Add(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public ICollection<Vehicle> Get()
        {
            return vehicles; 
        }

        public Vehicle Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
