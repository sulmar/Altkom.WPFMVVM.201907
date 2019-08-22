using System;
using System.Collections.Generic;
using System.Text;

namespace SWOP.Transport.Models.Reports
{
    public class Report : ReportBase
    {
        public Report(string name, string description, 
            IReadOnlyCollection<ReportDetail> details)
            : base(name, description)
        {
        }

        public IReadOnlyCollection<ReportDetail> Details { get; }
    }

    public class ReportDetail : Base
    {
        public VehicleType Type { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
    }
   
}
