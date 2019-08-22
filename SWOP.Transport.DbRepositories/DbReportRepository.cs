using SWOP.Transport.DbRepositories.Properties;
using SWOP.Transport.IRepositories;
using SWOP.Transport.Models.Reports;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            var details = context.Vehicles
                .GroupBy( v => new { v.Type, v.Brand })
                .Select( g => new ReportDetail { Type = g.Key.Type, Brand = g.Key.Brand, Quantity = g.Count() })
                .ToList();

            Report report = new Report("Raport", "Lorem ipsum", details);

            return report;
        }

        public VehicleByDateReport GetVehicleByDateReport(bool isRemoved)
        {
            // string sql = "select year(CreatedAt) as [year], month(CreatedAt) as [month], count(*) as quantity from Vehicles where IsRemoved = @IsRemoved group by year(CreatedAt), month(CreatedAt)";

            string sql = Resources.VehicleByDateReport;

            SqlParameter isRemovedParameter = new SqlParameter("IsRemoved", isRemoved);

            var details = context.Database.SqlQuery<VehicleByDateReportDetail>(sql, isRemovedParameter).ToList();

            var details2 = context.Database.SqlQuery<VehicleByDateReportDetail>("uspGetVehicleByDateReport", isRemovedParameter).ToList();

            return new VehicleByDateReport("Raport pojazdów", "Lorem ipsum", details);

        }

        public VehicleOwnerReport GetVehicleOwnerReport()
        {
            var details = context.Vehicles
                .Where(v => !v.IsRemoved)
                .GroupBy(v => v.Owner)
                .Select(g => new VehicleOwnerReportDetail { Employee = g.Key, Quantity = g.Count() })
                .ToList();

            return new VehicleOwnerReport("Raport 2", "Lorem ipsum", details);
        }
    }
}
