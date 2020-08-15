﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Advertise.Core.Models.Newsletter;
//using Advertise.Service.Services.Newsletters;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Newsletters
{
    public class NewsletterCreateValidator:BaseValidator<NewsletterCreateViewModel>
    {
        public NewsletterCreateValidator(/*INewsletterService newsletterService*/)
        {
            RuleFor(model => model.Email).NotNull().WithMessage("ایمیل را وارد کنید");
            RuleFor(model => model.Meet).NotNull().WithMessage("نحوه آشنایی را وارد کنید");
            //RuleFor(model => model.Email).MustAsync(async (userId, email, token) => !await newsletterService.IsEmailExistAsync(userId:null,email:email,cancellationToken:token)).WithMessage("ایمیل تکراری است");
        }
    }
}
