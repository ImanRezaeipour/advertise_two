using Advertise.Core.Models.SpecificationOption;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Specifications
{
    public class SpecificationOptionEditValidator : BaseValidator<SpecificationOptionEditViewModel>
    {
        public SpecificationOptionEditValidator()
        {
            RuleFor(model => model.CategoryId).IsNotNullGuid().WithMessage("دسته را انتخاب کنید");
            RuleFor(model => model.SpecificationId).IsNotNullGuid().WithMessage("مشخصه را وارد کنید");
        }
    }
}