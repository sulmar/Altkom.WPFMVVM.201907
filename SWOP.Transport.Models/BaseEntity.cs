using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SWOP.Transport.Models
{

    public abstract class Base : INotifyDataErrorInfo
    {
        // PM> Install-Package FluentValidation
        // PM> Install-Package FluentValidation.ValidatorAttribute

        private IValidator validator => new AttributedValidatorFactory().GetValidator(this.GetType());

        public bool HasErrors => !(validator?.Validate(this).IsValid ?? true);

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            var properties = new List<string> { propertyName };

            var context = new ValidationContext(
                this,
                new PropertyChain(),
                new MemberNameValidatorSelector(properties));

            var result = validator.Validate(context);

            return result.Errors;
        }
    }

    public abstract class BaseEntity : Base
    {
        public int Id { get; set; }
    }
}
