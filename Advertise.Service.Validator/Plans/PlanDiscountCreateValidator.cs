using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Models.PlanDiscount;
using Advertise.Core.Models.PlanPayment;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Plans
{
    public class PlanDiscountCreateValidator :BaseValidator<PlanDiscountCreateViewModel>
    {
        public PlanDiscountCreateValidator()
        {
            //:todo
            RuleFor(model => model.Code).NotNull().WithMessage("کد تخفیف را وارد کنید");
            RuleFor(model => model.Code).MinimumLength(6).MaximumLength(10).WithMessage("کد تخفیف باید بیشتر از 6 و کتر از 10 کاراکتر باشد");
            RuleFor(model => model.Count).NotNull().WithMessage("تعداد تخفیف را وارد کنید");
            RuleFor(model => model.Max).NotNull().WithMessage("حداکثر مبلغ تخفیف را وارد کنید");
            RuleFor(model => model.Percent).NotNull().WithMessage("درصد تخفیف را وارد کنید");
        }
    }
}
