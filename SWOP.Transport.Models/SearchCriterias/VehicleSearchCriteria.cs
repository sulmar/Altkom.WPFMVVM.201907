using System;
using System.Collections.Generic;
using System.Text;

namespace SWOP.Transport.Models.SearchCriterias
{
    public class DateRange
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }

    public class VehicleSearchCriteria
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public DateRange Period { get; set; }
    }
}
