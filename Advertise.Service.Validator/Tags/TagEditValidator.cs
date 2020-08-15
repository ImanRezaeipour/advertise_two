using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Models.Tag;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Tags
{
   public class TagEditValidator:BaseValidator<TagEditViewModel>
    {
        public TagEditValidator()
        {
            RuleFor(model => model.Title).NotNull().WithMessage("عنوان را وارد کنید");
            RuleFor(model => model.CostValue).Matches("^[۰-۹0-9_]*$").WithMessage("عدد وارد شود");
        }
    }
}
