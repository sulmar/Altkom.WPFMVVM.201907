using SWOP.Transport.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWOP.Transport.IRepositories
{
    public interface IRoleRepository : IEntityRepository<Role>
    {
        ICollection<Role> GetByEmployee(Employee employee);
    }
}
