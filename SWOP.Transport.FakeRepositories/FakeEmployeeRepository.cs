using SWOP.Transport.FakeRepositories.Fakers;
using SWOP.Transport.IRepositories;
using SWOP.Transport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWOP.Transport.FakeRepositories
{
    

    public class FakeEmployeeRepository : IEmployeeRepository
    {
        private ICollection<Employee> employees;

        private PolicemanFaker policemanFaker;
        private CivilFaker civilFaker;

        public FakeEmployeeRepository()
        {
            policemanFaker = new PolicemanFaker();
            civilFaker = new CivilFaker();

           // employees = policemanFaker.Generate(20);

            var policemans = new List<Employee>(policemanFaker.Generate(50));
            var civils = new List<Civil>(civilFaker.Generate(50));

            employees = policemans.Concat(civils).ToList();

        }


        public void Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee Authorize(string username, string password)
        {
            return employees
                .SingleOrDefault(p => p.UserName == username && p.HashPassword == password);
        }

        public ICollection<Employee> Get()
        {
            return employees;
        }

        public Employee Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
