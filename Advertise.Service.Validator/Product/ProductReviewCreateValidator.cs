using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Models.ProductReview;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Product
{
    public class ProductReviewCreateValidator :BaseValidator<ProductReviewCreateViewModel>
    {
        public ProductReviewCreateValidator()
        {
            RuleFor(model => model.Body).NotNull().WithMessage("متن نقد و بررسی را وارد کنید");
            RuleFor(model => model.ProductId).NotNull().WithMessage("محصول مورد نقد را انتخاب کنید");
        }
    }
}
