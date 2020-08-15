using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Models.Receipt;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Receipts
{
    public class ReceiptCreateValidator:BaseValidator<ReceiptViewModel>
    {
        public ReceiptCreateValidator()
        {
            RuleFor(model => model.FirstName).NotNull().WithMessage("نام خود را وارد کنید");
            RuleFor(model => model.LastName).NotNull().WithMessage("نام خانوادگی خود را وارد کنید");
            RuleFor(model => model.NationalCode).NotNull().WithMessage("کد ملی را وارد کنید");
            RuleFor(model => model.NationalCode).MinimumLength(10).MaximumLength(10).WithMessage("کد ملی باید ده رقم باشد");
            RuleFor(model => model.NationalCode).Matches("^[۰-۹0-9_]*$").WithMessage("کد ملی باید عدد باشد");
            RuleFor(model => model.HomeNumber).NotNull().WithMessage("شماره تلفن ثابت را وارد کنید");
            RuleFor(model => model.HomeNumber).MinimumLength(10).MaximumLength(10).WithMessage("شماره تلفن باید 11 رقم باشد");
            RuleFor(model => model.HomeNumber).Matches("^[۰-۹0-9_]*$").WithMessage("شماره تلفن باید عدد باشد");
            RuleFor(model => model.PhoneNumber).NotNull().WithMessage("شماره همراه را وارد کنید");
            RuleFor(model => model.PhoneNumber).MinimumLength(10).MaximumLength(10).WithMessage("شماره همراه باید 11 رقم باشد");
            RuleFor(model => model.PhoneNumber).Matches("^[۰-۹0-9_]*$").WithMessage("شماره همراه باید عدد باشد");
            RuleFor(model => model.Payment).NotNull().WithMessage("نوع پرداخت را انتخاب نمائید");
            RuleFor(model => model.Address.City.Id).NotNull().WithMessage("لطفا استان محل سکونت خود را تعیین نمایید");
            RuleFor(model => model.Address.Extra).NotNull().WithMessage("لطفا نشانی خود را وارد نمایید");
            RuleFor(model => model.Address.City.ParentId).NotNull().WithMessage("لطفا استان محل سکونت خود را تعیین نمایید");
        }
    }
}
