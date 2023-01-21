using FluentValidation;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.FluentValidators
{
    public class AddressValidator:AbstractValidator<Address>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} field cannot be empty";
        public AddressValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Province).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.PostCode).NotEmpty().WithMessage(NotEmptyMessage).MaximumLength(5)
                .WithMessage("The {PropertyName} field must be a maximum of {MaxLength} characters");

        }

    }
}
