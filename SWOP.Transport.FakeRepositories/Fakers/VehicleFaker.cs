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
            RuleFor(p => p.PlateNumber, f => f.Random.String(2) + f.Random.Number(5));
            RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.3f));
            Ignore(p => p.CreatedAt);
        }
    }
}
