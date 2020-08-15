using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Models.Complaint;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Complaints
{
    public class ComplaintCreateValidator : BaseValidator<ComplaintCreateViewModel>
    {
        public ComplaintCreateValidator()
        {
            RuleFor(model => model.Body).NotNull().WithMessage("متن شکایت را وارد کنید");
            RuleFor(model => model.Body).MinimumLength(10).MaximumLength(200).WithMessage("متن شکایت باید بیشتر از 10 و کمتر از 200 کاراکتر باشد");
            RuleFor(model => model.Title).NotNull().WithMessage("عنوان را وارد کنید");
            RuleFor(model => model.Title).MinimumLength(2).MaximumLength(30).WithMessage("عنوان باید بیشتر از 2 و کمتر از 30 کاراکتر باشد");
        }
    }
}
