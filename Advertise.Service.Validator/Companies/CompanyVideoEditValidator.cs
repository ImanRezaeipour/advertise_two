using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Models.CompanyVideo;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Companies
{
    public class CompanyVideoEditValidator:BaseValidator<CompanyVideoEditViewModel>
    {
        public CompanyVideoEditValidator()
        {
            RuleFor(model => model.Title).NotNull().WithMessage("عنوان را وارد کنید");
            RuleFor(model => model.Title).MinimumLength(2).MaximumLength(30).WithMessage("عنوان باید بیشتر از 2 و کمتر از 30 کاراکتر باشد");
        }
    }
}
