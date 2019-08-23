using SWOP.Transport.DbRepositories.Interceptors;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWOP.Transport.DbRepositories
{
    class MyDbConfiguration : DbConfiguration
    {
        public MyDbConfiguration()
        {
            var tableNames = new List<string> { "Vehicles", "Employees" };

           //  this.AddInterceptor(new MyCommandInterceptor(tableNames));
        }
    }
}
