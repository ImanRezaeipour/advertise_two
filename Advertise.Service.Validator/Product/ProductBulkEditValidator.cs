using Advertise.Core.Models.Product;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Product
{
    public class ProductBulkEditValidator : BaseValidator<ProductBulkEditViewModel>
    {
        #region Public Constructors

        public ProductBulkEditValidator()
        {
            RuleFor(model => model.ProductBulks).SetCollectionValidator(new ProductBulkValidator());
        }

        #endregion Public Constructors

    }
}