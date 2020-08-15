using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Models.Company;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Companies
{
    public class CompanyCreateValidator:BaseValidator<CompanyCreateViewModel>
    {
        public CompanyCreateValidator()
        {
            RuleFor(model => model.Title).NotNull().WithMessage("عنوان وارد شود");
            RuleFor(model => model.CategoryId).NotNull().WithMessage("دسته کاری را وارد شود");
            RuleFor(model => model.MobileNumber).Matches("^[۰-۹0-9_]*$").WithMessage("شماره موبایل عدد وارد شود");
            RuleFor(model => model.MobileNumber).MaximumLength(11).MinimumLength(11).WithMessage("شماره موبایل 11 رقم وارد شود");
            RuleFor(model => model.Title).MaximumLength(30).MinimumLength(2).WithMessage("عنوان باید بیشتر از2 و کمتر از 30 کاراکتر باشد");
        }
    }
}
