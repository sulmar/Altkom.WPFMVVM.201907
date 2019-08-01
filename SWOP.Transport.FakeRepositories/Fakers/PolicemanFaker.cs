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
            //RuleFor(p => p.UserName, f => f.Person.UserName);
            RuleFor(p => p.UserName, f => "altkom" + f.IndexFaker);
            RuleFor(p => p.HashPassword, f => "12345");
        }
    }
}
