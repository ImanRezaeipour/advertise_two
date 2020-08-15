using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Models.User;
//using Advertise.Service.Services.Users;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Accounts
{
    public class UserVerifyPhoneNumberValidator :BaseValidator<UserVerifyPhoneNumberViewModel>
    {
        public UserVerifyPhoneNumberValidator(/*IUserService userService*/)
        {
            //RuleFor(model => model.UserId).MustAsync(userService.IsExistByIdCancellationTokenAsync).WithMessage("این نام کاربری وجود ندارد");
            //RuleFor(model => model.UserId).MustAsync(userService.IsBanByIdAsync).WithMessage("حساب کاربری شما مسدود شده است");
            //RuleFor(model => model.UserId).MustAsync(userService.IsLockedOutAsync).WithMessage("حساب کاربری شما قفل شده است");
        }
    }
}
