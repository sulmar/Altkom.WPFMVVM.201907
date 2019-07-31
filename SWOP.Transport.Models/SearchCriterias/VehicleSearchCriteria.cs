using FluentValidation.Attributes;
using SWOP.Transport.Models.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWOP.Transport.Models.SearchCriterias
{
    public class DateRange : Base
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }

    [Validator(typeof(VehicleSearchCriteriaValidator))]
    public class VehicleSearchCriteria : Base
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public string PlateNumber { get; set; }
        public DateRange Period { get; set; }


        public VehicleSearchCriteria()
        {
            Period = new DateRange();
        }
    }
}
