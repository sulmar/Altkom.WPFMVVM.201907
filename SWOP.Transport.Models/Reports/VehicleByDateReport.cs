using System.Collections.Generic;

namespace SWOP.Transport.Models.Reports
{
    public class VehicleByDateReport : ReportBase
    {
        public VehicleByDateReport(string name, string description,
            IReadOnlyCollection<VehicleByDateReportDetail> details
            ) : base(name, description)
        {
            Details = details;
        }

        public IReadOnlyCollection<VehicleByDateReportDetail> Details { get; }
    }

    public class VehicleByDateReportDetail : Base
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Quantity { get; set; }
    }
}
