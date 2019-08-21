using Bogus;
using SWOP.Transport.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
 
namespace SWOP.Transport.FakeRepositories.Fakers
{
    public class PolicemanFaker : Faker<Policeman>
    {
        public PolicemanFaker()
        {
            var roles = new List<Role>
            {
                new Role("user"),
                new Role("trainer"),
            };

            StrictMode(true);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.Grade, f => f.PickRandom<Grade>());
            //RuleFor(p => p.UserName, f => f.Person.UserName);
            RuleFor(p => p.UserName, f => "altkom" + f.IndexFaker);
            RuleFor(p => p.HashPassword, f => "12345");
            RuleFor(p => p.Phone, f => f.Person.Phone);
            RuleFor(p => p.CellPhone, f => "555123321");
            RuleFor(p => p.Email, (f, e) => $"{e.FirstName}.{e.LastName}@altkom.pl");
            RuleFor(p => p.CreatedAt, f => f.Date.Past(5));
            Ignore(p => p.ModifiedAt);
            Ignore(p => p.Vehicles);
            RuleFor(p => p.Roles, f => Enumerable.Range(1, f.Random.Int(1, roles.Count))
                                        .Select(role => f.PickRandom(roles)).ToList());
        }
    }
}
