using Advertise.Core.Models.CompanyImage;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Companies
{
    public class CompanyImageCreateValidator : BaseValidator<CompanyImageCreateViewModel>
    {
        public CompanyImageCreateValidator()
        {
            RuleFor(model => model.Title).NotNull().WithMessage("عنوان گالری عکس را وارد کنید");
            RuleFor(model => model.Title).MinimumLength(2).MaximumLength(30).WithMessage("عنوان فایل باید بیشتر از 2 و کمتر از 30 کاراکتر باشد");
        }
    }
}