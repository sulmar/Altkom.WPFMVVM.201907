using SWOP.Transport.IRepositories;
using SWOP.Transport.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
