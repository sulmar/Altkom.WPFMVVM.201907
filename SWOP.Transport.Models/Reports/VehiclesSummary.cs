using System;
using System.Collections.Generic;
using System.Text;

namespace SWOP.Transport.Models.Reports
{
    public class Report : Base
    {
        public string Description { get; set; }
        public IReadOnlyCollection<ReportDetail> Details { get; set; }
    }

    public class ReportDetail : Base
    {
        public VehicleType Type { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
    }
   
}
