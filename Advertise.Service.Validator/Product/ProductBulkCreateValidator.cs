using Advertise.Core.Models.Product;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Product
{
    public class ProductBulkCreateValidator : BaseValidator<ProductBulkCreateViewModel>
    {
        public ProductBulkCreateValidator()
        {
            RuleFor(model => model.ProductBulks).SetCollectionValidator(new ProductBulkValidator());
        }
    }
}