using Bogus;
using SWOP.Transport.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWOP.Transport.FakeRepositories.Fakers
{
    public class VehicleFaker : Faker<Vehicle>
    {
        public VehicleFaker()
        {
            StrictMode(true);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.Model, f => f.Vehicle.Model());
            RuleFor(p => p.Brand, f => f.Vehicle.Manufacturer());
            RuleFor(p => p.PlateNumber, f => f.Lorem.Letter(2).ToUpper() + f.Random.Number(1000, 9999).ToString());
            RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.3f));
            RuleFor(p => p.Type, f => f.PickRandom<VehicleType>());
            Ignore(p => p.CreatedAt);
        }
    }
}
