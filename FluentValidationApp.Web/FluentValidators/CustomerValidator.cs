using FluentValidation;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.FluentValidators
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name Field Cannot Be Empty");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Field Cannot Be Empty").EmailAddress().WithMessage("Email field must be in the correct format");
        }
    }
}
