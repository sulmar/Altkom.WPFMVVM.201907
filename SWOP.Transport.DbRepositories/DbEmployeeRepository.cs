using SWOP.Transport.IRepositories;
using SWOP.Transport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWOP.Transport.DbRepositories
{
    public class DbEmployeeRepository : IEmployeeRepository
    {
        public void Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Employee Authorize(string username, string password)
        {
            throw new NotImplementedException();
        }

        public ICollection<Employee> Get()
        {
            throw new NotImplementedException();
        }

        public Employee Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
