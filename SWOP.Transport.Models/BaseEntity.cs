using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SWOP.Transport.Models
{

    public abstract class Base : INotifyDataErrorInfo, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                OnErrorsChanged(propertyName);


            }

        }
        #endregion

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

        protected void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

    }

    public abstract class BaseEntity : Base
    {
        public int Id { get; set; }
    }
}
