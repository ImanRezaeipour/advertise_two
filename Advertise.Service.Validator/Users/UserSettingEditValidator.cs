using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Models.UserSetting;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Users
{
    public class UserSettingEditValidator:BaseValidator<UserSettingEditViewModel>
    {
        public UserSettingEditValidator()
        {
            RuleFor(model => model.Language).NotNull().WithMessage("زبان وارد شود");
            RuleFor(model => model.Theme).NotNull().WithMessage("تم وارد شود");
        }
    }
}
