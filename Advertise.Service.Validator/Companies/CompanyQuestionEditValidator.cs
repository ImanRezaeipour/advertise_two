using Advertise.Core.Models.CompanyQuestion;
using Advertise.Service.Validators.Common;
using FluentValidation;

namespace Advertise.Service.Validators.Companies
{
    public class CompanyQuestionEditValidator:BaseValidator<CompanyQuestionEditViewModel>
    {
        public CompanyQuestionEditValidator()
        {
            RuleFor(model => model.Body).NotNull().WithMessage("لطفا سوال خود را بنویسید");
            RuleFor(model => model.Body).MinimumLength(3).MaximumLength(200).WithMessage("سوال باید بیشتر از 3 و کمتر از 200 کاراکتر باشد");
        }
    }
}