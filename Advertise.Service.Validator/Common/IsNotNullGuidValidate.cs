using FluentValidation.Validators;
using System;

namespace Advertise.Service.Validators.Common
{
    public class IsNotNullGuidValidate : PropertyValidator
    {
        #region Public Constructors

        public IsNotNullGuidValidate() : base("فیلد {PropertyName} را انتخاب کنید")
        {
        }

        #endregion Public Constructors

        #region Protected Methods

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null)
                return false;
          
            Guid value;
            if (Guid.TryParse(context.PropertyValue.ToString(), out value) == false)
                return false;

            if (value == Guid.Empty)
                return false;

            return true;
        }

        #endregion Protected Methods
    }
}