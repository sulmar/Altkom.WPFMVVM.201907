using SWOP.Transport.IRepositories;
using SWOP.Transport.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SWOP.Transport.DbRepositories
{

    public class DbEmployeeRepository : DbEntityRepository<Employee>, IEmployeeRepository
    {
        public DbEmployeeRepository(TransportContext context) 
            : base(context)
        {
        }

        public Employee Authorize(string username, string password)
        {
            return entities
              .SingleOrDefault(p => p.UserName == username && p.HashPassword == password);
        }

        public override ICollection<Employee> Get()
        {
            // using System.Data.Entity;
            return entities.Include(p=>p.Roles).ToList();
        }

     
    }
}
