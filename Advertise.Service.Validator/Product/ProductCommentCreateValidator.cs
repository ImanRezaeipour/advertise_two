using Advertise.Core.Models.ProductComment;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Product
{
    public class ProductCommentCreateValidator : BaseValidator<ProductCommentCreateViewModel>
    {
        public ProductCommentCreateValidator()
        {
            RuleFor(model => model.Body).NotNull().MinimumLength(2).MaximumLength(200).WithMessage("متن را وارد کنید");
            RuleFor(model => model.ProductId).NotNull().WithMessage("محصول نامشخص است");
        }
    }
}