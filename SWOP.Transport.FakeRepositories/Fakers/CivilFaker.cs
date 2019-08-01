using Bogus;
using SWOP.Transport.Models;

namespace SWOP.Transport.FakeRepositories.Fakers
{
    public class CivilFaker : Faker<Civil>
    {
        public CivilFaker()
        {
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.UserName, f => "altkom" + f.IndexFaker + 100);
            RuleFor(p => p.HashPassword, f => "54321");
        }
    }
}
