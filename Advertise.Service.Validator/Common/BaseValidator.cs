using FluentValidation;

namespace Advertise.Service.Validators.Common
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        #region Public Constructors

        protected BaseValidator()
        {
            //CascadeMode = CascadeMode.StopOnFirstFailure;
        }

        #endregion Public Constructors
    }
}