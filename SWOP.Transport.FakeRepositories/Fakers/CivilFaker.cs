using Bogus;
using SWOP.Transport.Models;

namespace SWOP.Transport.FakeRepositories.Fakers
{
    public class CivilFaker : Faker<Civil>
    {
        public CivilFaker()
        {
            StrictMode(true);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.UserName, f => "altkom" + f.IndexFaker + 100);
            RuleFor(p => p.HashPassword, f => "54321");
            RuleFor(p => p.Phone, f => f.Person.Phone);
            RuleFor(p => p.CellPhone, f => f.Person.Phone);
            RuleFor(p => p.Email, (f, e) => $"{e.FirstName}.{e.LastName}@altkom.pl");
            Ignore(p => p.Vehicles);
        }
    }
}
