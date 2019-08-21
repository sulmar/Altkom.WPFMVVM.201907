using Bogus;
using SWOP.Transport.Models;
using System.Collections.Generic;
using System.Linq;

namespace SWOP.Transport.FakeRepositories.Fakers
{
    public class CivilFaker : Faker<Civil>
    {
        public CivilFaker()
        {
            var roles = new List<Role>
            {
                new Role("administrator"),
                new Role("developer"),
                new Role("trainer"),
            };

            StrictMode(true);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.UserName, f => "altkom" + f.IndexFaker + 100);
            RuleFor(p => p.HashPassword, f => "54321");
            RuleFor(p => p.Phone, f => f.Person.Phone);
            RuleFor(p => p.CellPhone, f => "555123321");
            RuleFor(p => p.Email, (f, e) => $"{e.FirstName}.{e.LastName}@altkom.pl");
            Ignore(p => p.Vehicles);
            RuleFor(p => p.CreatedAt, f => f.Date.Past(5));
            Ignore(p => p.ModifiedAt);
            RuleFor(p => p.Roles, f => Enumerable.Range(1, f.Random.Int(1, roles.Count))
                                       .Select(role => f.PickRandom(roles)).ToList());
        }
    }
}
