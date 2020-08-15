using FluentValidation;
using System;

namespace Advertise.Service.Validators.Common
{
    public static class FluentValidationExtentions
    {
        public static IRuleBuilderOptions<TItem, Guid> IsNotNullGuid<TItem>(this IRuleBuilder<TItem, Guid> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new IsNotNullGuidValidate());
        }

        public static IRuleBuilderOptions<TItem, Guid?> IsNotNullGuid<TItem>(this IRuleBuilder<TItem, Guid?> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new IsNotNullGuidValidate());
        }
    }
}