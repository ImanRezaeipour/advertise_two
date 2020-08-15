using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Models.ProductComment;
using Advertise.Service.Validators.Common;
using FluentValidation;
using StructureMap.Building;

namespace Advertise.Service.Validators.Product
{
   public class ProductCommentEditValidator:BaseValidator<ProductCommentEditViewModel>
    {
        public ProductCommentEditValidator()
        {
            RuleFor(model => model.Body).NotNull().MaximumLength(2).MaximumLength(200).WithMessage("متن را وارد کنید");
            RuleFor(model => model.ProductId).NotNull().WithMessage("محصول نامشخص است");
        }
    }
}
