using SWOP.Transport.IRepositories;
using SWOP.Transport.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWOP.Transport.DbRepositories
{
    public class DbReportRepository : IReportRepository
    {
        private readonly TransportContext context;

        public DbReportRepository(TransportContext context)
        {
            this.context = context;
        }

        public Report Get()
        {
            throw new NotImplementedException();
        }
    }
}
