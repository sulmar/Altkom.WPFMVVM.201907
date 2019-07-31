using FluentValidation;
using SWOP.Transport.Models.SearchCriterias;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWOP.Transport.Models.Validators
{
    // FluentValidation
    public class VehicleSearchCriteriaValidator : AbstractValidator<VehicleSearchCriteria>
    {
        public VehicleSearchCriteriaValidator()
        {
            RuleFor(p => p.Brand).NotEmpty();
            RuleFor(p => p.PlateNumber).Length(4, 7);
        }
    }

    internal class DateRangeValidator : AbstractValidator<DateRange>
    {
        public DateRangeValidator()
        {
            RuleFor(p => p.From).LessThanOrEqualTo(p => p.To);
        }
    }
}
