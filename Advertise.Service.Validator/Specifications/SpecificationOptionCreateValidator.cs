using Advertise.Core.Models.SpecificationOption;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Specifications
{
    public class SpecificationOptionCreateValidator : BaseValidator<SpecificationOptionCreateViewModel>
    {
        public SpecificationOptionCreateValidator()
        {
            RuleFor(model => model.CategoryId).IsNotNullGuid().WithMessage("دسته را انتخاب کنید");
            RuleFor(model => model.SpecificationId).IsNotNullGuid().WithMessage("مشخصه را وارد کنید");
        }
    }
}