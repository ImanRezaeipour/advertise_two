using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Models.News;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.News
{
    public class NewsCreateValidator:BaseValidator<NewsCreateViewModel>
    {
        public NewsCreateValidator()
        {
            RuleFor(model => model.Body).NotNull().WithMessage("متن را وارد کنید");
            RuleFor(model => model.Title).NotNull().WithMessage("عنوان را وارد کنید");
            RuleFor(model => model.Title).MinimumLength(2).MaximumLength(30).WithMessage("عنوان باید بیشتر از 2 و کمتر از 30 ;hvh;jv fhan");

        }
    }
}
