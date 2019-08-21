using Bogus;
using SWOP.Transport.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWOP.Transport.FakeRepositories.Fakers
{
    public class DeadlineFaker : Faker<Deadline>
    {
        public DeadlineFaker()
        {
            StrictMode(true);
            RuleFor(p => p.Date, f => f.Date.Future(1));
            RuleFor(p => p.Type, f => f.PickRandom<DeadlineType>());
        }
    }
}
