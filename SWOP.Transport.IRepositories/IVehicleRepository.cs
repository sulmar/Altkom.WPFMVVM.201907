using SWOP.Transport.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SWOP.Transport.IRepositories
{
    public interface IVehicleRepository
    {
        ICollection<Vehicle> Get();
        Vehicle Get(int id);
        void Add(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Remove(int id);
    }
}
