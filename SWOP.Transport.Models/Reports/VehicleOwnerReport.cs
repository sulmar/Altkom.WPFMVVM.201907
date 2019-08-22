using System.Collections.Generic;
using System.Text;

namespace SWOP.Transport.Models.Reports
{

    

    public class VehicleOwnerReport : ReportBase
    {
        public IReadOnlyCollection<VehicleOwnerReportDetail> Details { get; }

        public VehicleOwnerReport(
            string name, 
            string description, 
            IReadOnlyCollection<VehicleOwnerReportDetail> details) 
            : base(name, description)
        {
            Details = details;
        }
    }

    public class VehicleOwnerReportDetail : Base
    {
        public Employee Employee { get; set; }
        public int Quantity { get; set; }
    }
}
