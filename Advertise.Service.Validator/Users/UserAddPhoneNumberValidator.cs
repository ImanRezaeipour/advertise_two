using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Models.User;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Users
{
    public class UserAddPhoneNumberValidator:BaseValidator<UserAddPhoneNumberViewModel>
    {
        public UserAddPhoneNumberValidator()
        {
            RuleFor(model => model.Number).NotNull().WithMessage("شماره موبایل را وارد کنید");
            RuleFor(model => model.Number).MinimumLength(11).MaximumLength(11).WithMessage("شماره موبایل 11 رقم باشد");
            RuleFor(model => model.Number).Matches("^[۰-۹0-9_]*$").WithMessage("شماره موبایل عدد باشد");
        }
    }
}
