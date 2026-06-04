using FluentValidation;
using RestauranteUni.Domain.ValuesObjects;

namespace RestauranteUni.Application.Utils
{
    internal sealed class EmailValidation : AbstractValidator<string>
    {
        public EmailValidation()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("E-mail is required")
                .Must(Email.IsValid)
                .WithMessage("Invalid e-mail");
        }
    }
}
