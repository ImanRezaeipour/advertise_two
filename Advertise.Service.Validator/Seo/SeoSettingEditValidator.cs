using Advertise.Core.Models.SeoSetting;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Seo
{
    public class SeoSettingEditValidator:BaseValidator<SeoSettingEditViewModel>
    {
        public SeoSettingEditValidator()
        {
            RuleFor(model => model.WwwRequirement).NotNull().WithMessage("وضعیت را وارد کنید www");
        }
    }
}
