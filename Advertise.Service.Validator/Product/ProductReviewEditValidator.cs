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
    public class ProductReviewEditValidator :BaseValidator<ProductReviewEditViewModel>
    {
        public ProductReviewEditValidator()
        {
            RuleFor(model => model.Body).NotNull().WithMessage("متن نقد و بررسی را وارد کنید");
        }
    }
}
