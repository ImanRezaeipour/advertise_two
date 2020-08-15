using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Models.Role;
//using Advertise.Service.Services.Users;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Roles
{
    public class RoleEditValidator:BaseValidator<RoleEditViewModel>
    {
        public RoleEditValidator(/*IRoleService roleService*/)
        {
            RuleFor(model => model.Name).NotNull().WithMessage("نام را انتخاب نمایید");
            //RuleFor(model => model.Name).MustAsync(roleService.IsExistNameAsync).WithMessage("این گروه  قبلا در سیستم ثبت شده است");
            RuleFor(model => model.Name).MinimumLength(6).MaximumLength(30).WithMessage("نام باید کمتر از 30 و بیشتر از 8 کاراکتر باشد");
        }
    }
}
