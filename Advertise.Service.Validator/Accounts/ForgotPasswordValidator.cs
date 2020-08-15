using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Advertise.Core.Domains.Users;
using Advertise.Core.Models.Account;
//using Advertise.Service.Services.Users;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Accounts
{
    public class ForgotPasswordValidator : BaseValidator<ForgotPasswordViewModel>
    {
        public ForgotPasswordValidator(/*IUserService userService*/)
        {
            //var http = HttpContext.Current;
            //RuleFor(model => model.Email).MustAsync(userService.IsExistByEmailCancellationTokenAsync).WithMessage("این پست الکترونیک ثبت نشده است");
            //RuleFor(model => model.Email).MustAsync((username, token) => userService.IsEmailConfirmedByEmailAsync(username,http, token)).WithMessage("این پست الکترونیک تایید نشده است");
        }
    }
}
