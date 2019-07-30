using Bogus;
using SWOP.Transport.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWOP.Transport.FakeRepositories.Fakers
{
    public class PolicemanFaker : Faker<Policeman>
    {
        public PolicemanFaker()
        {
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.Grade, f => f.PickRandom<Grade>());
        }
    }

    public class CivilFaker : Faker<Civil>
    {
        public CivilFaker()
        {
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
        }
    }
}
