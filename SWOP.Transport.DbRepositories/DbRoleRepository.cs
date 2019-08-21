using SWOP.Transport.IRepositories;
using SWOP.Transport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWOP.Transport.DbRepositories
{
    public class DbRoleRepository : DbEntityRepository<Role>, IRoleRepository
    {
        public DbRoleRepository(TransportContext context) : base(context)
        {
        }

        public ICollection<Role> GetByEmployee(Employee employee)
        {
            return entities
                .Where(role => role.Employees.Any(e=>e.Id == employee.Id))
                .ToList();
        }
    }
}
