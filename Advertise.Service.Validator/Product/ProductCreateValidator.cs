using Advertise.Core.Models.Product;
//using Advertise.Service.Services.Companies;
using Advertise.Service.Validators.Common;
using FluentValidation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Advertise.Service.Validators.Product
{
    public class ProductCreateValidator : BaseValidator<ProductCreateViewModel>
    {
        #region Private Fields


        #endregion Private Fields

        #region Public Constructors

        public ProductCreateValidator(/*ICompanyService companyService*/)
        {

            RuleFor(model => model.CategoryId).NotNull().WithMessage("دسته بندی را انتخاب کنید");
            RuleFor(model => model.Price).NotNull().WithMessage("قیمت را انتخاب کنید");
            RuleFor(model => model.Sell).NotNull().WithMessage("نوع فروش را انتخاب کنید");
            //RuleFor(model => model.CompanyId).MustAsync(companyService.HasAliasAsync).WithMessage("فروشگاه شما ایجاد نشده است");
            RuleFor(model => model.Title).NotNull().WithMessage("عنوان را انتخاب کنید");
            RuleFor(model => model.Title).MinimumLength(2).MaximumLength(50).WithMessage("عنوان باید بیشتر از 2 و کمتر از 30 کاراکتر باشد");

        }

        #endregion Public Constructors

    }
}