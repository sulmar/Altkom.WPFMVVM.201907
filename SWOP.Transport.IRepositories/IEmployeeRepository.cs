using SWOP.Transport.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWOP.Transport.IRepositories
{
    //public interface IEmployeeRepository
    //{
    //    ICollection<Employee> Get();
    //    Employee Get(int id);
    //    void Add(Employee employee);
    //    void Update(Employee employee);
    //    void Remove(int id);
    //}

    public interface IEmployeeRepository : IEntityRepository<Employee>
    {
        Employee Authorize(string username, string password);
    }

}
