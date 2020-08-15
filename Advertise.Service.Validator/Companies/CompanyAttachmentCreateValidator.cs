using Advertise.Core.Models.CompanyAttachment;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Companies
{
    public class CompanyAttachmentCreateValidator : BaseValidator<CompanyAttachmentCreateViewModel>
    {
        public CompanyAttachmentCreateValidator()
        {
            RuleFor(model => model.Title).NotNull().WithMessage("عنوان فایل را وارد کنید");
            RuleFor(model => model.Title).MinimumLength(2).MaximumLength(30).WithMessage("عنوان فایل باید بیشتر از 2 و کمتر از 30 کاراکتر باشد");
        }
    }
}