using Advertise.Core.Models.Account;
//using Advertise.Service.Services.Users;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Users
{
    public class RegisterValidator : BaseValidator<RegisterViewModel>
    {
        public RegisterValidator(/*IUserService userService*/)
        {
            RuleFor(model => model.Email).NotNull().WithMessage("ایمیل را وارد کنید");
            RuleFor(model => model.Password).NotNull().WithMessage("پسورد را وارد کنید");
            RuleFor(model => model.Password).MinimumLength(6).MaximumLength(100).WithMessage("پسورد باید بیشتر از6 و کمتر از 100 کاراکتر باشد");
            RuleFor(model => model.TermOfService).NotNull().WithMessage("قوانین را قبول ندارید؟");
            //RuleFor(model => model.Email).MustAsync(async (email, token) => !await userService.IsExistByEmailCancellationTokenAsync(email,token)).WithMessage("این پست الکترونیک وجود دارد");
        }
    }
}