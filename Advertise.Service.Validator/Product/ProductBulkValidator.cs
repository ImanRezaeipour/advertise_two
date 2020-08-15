using Advertise.Core.Models.Product;
//using Advertise.Service.Services.Companies;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Product
{
    public class ProductBulkValidator : BaseValidator<ProductBulkViewModel>
    {
        #region Public Constructors

        public ProductBulkValidator()
        {
            RuleFor(model => model.CatalogId).NotNull().When(model => model.Id == null).WithMessage("کاتالوگ را انتخاب کنید");
            RuleFor(model => model.CategoryId).NotNull().When(model => model.Id == null).WithMessage("دسته را انتخاب کنید");
            RuleFor(model => model.Color).NotNull().When(model => model.Id == null).WithMessage("رنگ را انتخاب کنید");
            RuleFor(model => model.Price).NotNull().WithMessage("قیمت را وارد کنید");
            RuleFor(model => model.AvailableCount).NotNull().WithMessage("موجودی را وارد کنید");
        }

        #endregion Public Constructors
    }
}