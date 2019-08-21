using SWOP.Transport.IRepositories;
using SWOP.Transport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWOP.Transport.FakeRepositories
{
    public class FakeRoleRepository : IRoleRepository
    {
        private ICollection<Role> roles;

        public FakeRoleRepository()
        {
            roles = new List<Role>
            {
                new Role("administrator"),
                new Role("developer"),
                new Role("trainer"),
            };
        }

        public void Add(Role entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<Role> Get() => roles;

        public Role Get(int id) => roles.SingleOrDefault(p => p.Id == id);

        public ICollection<Role> GetByEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
