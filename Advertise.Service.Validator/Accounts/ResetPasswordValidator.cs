using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Models.Account;
//using Advertise.Service.Services.Users;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Accounts
{
    public class ResetPasswordValidator:BaseValidator<ResetPasswordViewModel>
    {
        public ResetPasswordValidator(/*IUserService userService*/)
        {
            //RuleFor(model => model.Email).MustAsync(userService.IsExistByEmailCancellationTokenAsync).WithMessage("این نام کاربری وجود ندارد");
        }
    }
}
