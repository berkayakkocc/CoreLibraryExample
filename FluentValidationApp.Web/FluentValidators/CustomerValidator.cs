using FluentValidation;
using FluentValidationApp.Web.Models;
using System.Security.Cryptography;

namespace FluentValidationApp.Web.FluentValidators
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} field cannot be boş";
        public CustomerValidator()
        {
            //RuleFor(x => x.Name).NotEmpty().WithMessage("Boş");
            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage)
                .EmailAddress().WithMessage("Email field must be in the correct format");
            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage).InclusiveBetween(18, 60).WithMessage("Age field must be between 18 and 60 years old.");
            RuleFor(x => x.BirthDay).NotEmpty().WithMessage(NotEmptyMessage).Must(x =>
            {
                return DateTime.Now.AddYears(-18) >= x;
            }).WithMessage("You must be over 18 years old");
        }
    }
}
