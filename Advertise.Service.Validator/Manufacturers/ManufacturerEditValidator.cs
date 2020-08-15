using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Models.Manufacturer;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Manufacturers
{
    public class ManufacturerEditValidator:BaseValidator<ManufacturerEditViewModel>
    {
        public ManufacturerEditValidator()
        {
            RuleFor(model => model.Country).NotNull().WithMessage("لطفاکشور را انتخاب کنید");
            RuleFor(model => model.Name).NotNull().WithMessage("لطفا نام برند را وارد کنید");
        }
    }
}
