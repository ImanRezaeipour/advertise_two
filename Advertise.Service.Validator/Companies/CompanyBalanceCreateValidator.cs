using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Models.CompanyBalance;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Companies
{
    public class CompanyBalanceCreateValidator:BaseValidator<CompanyBalanceCreateViewModel>
    {
        public CompanyBalanceCreateValidator()
        {
            RuleFor(model => model.Amount).NotNull().WithMessage(" مبلغ تراکنش را وارد نمائید");
            RuleFor(model => model.CompanyId).NotNull().WithMessage("شرکت مشخص نشده");
            RuleFor(model => model.Depositor).NotNull().WithMessage("واریز کننده را وارد کنید");
            RuleFor(model => model.DocumentNumber).NotNull().WithMessage("شماره سند را وارد کنید");
            RuleFor(model => model.IssueTracking).NotNull().WithMessage("شماره پیگیری را وارد کنید");
            RuleFor(model => model.SettingTransactionId).NotNull().WithMessage("شماره حساب نویناک وارد شود");
            RuleFor(model => model.TransactionedOn).NotNull().WithMessage("تاریخ و زمان تراکنش را وارد کنید");
        }
    }
}
