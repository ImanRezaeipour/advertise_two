using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Models.SeoUrl;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Seo
{
    public class SeoUrlCreateValidator :BaseValidator<SeoUrlCreateViewModel>
    {
        public SeoUrlCreateValidator()
        {
            RuleFor(model => model.AbsoulateUrl).NotNull().WithMessage("آدرس قبلی را وارد کنید");
            RuleFor(model => model.CurrentUrl).NotNull().WithMessage("آدرس جدید را وارد کنید");
            RuleFor(model => model.Redirection).NotNull().WithMessage("نوع انتقال را وارد کنید");
        }
    }
}
