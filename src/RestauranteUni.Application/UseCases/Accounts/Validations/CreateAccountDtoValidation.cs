using FluentValidation;
using RestauranteUni.Application.Utils;
using RestauranteUni.Domain.Accounts.DTO;
using RestauranteUni.Domain.ValuesObjects;

namespace RestauranteUni.Application.UseCases.Accounts.Validations
{
    public class CreateAccountDtoValidation : AbstractValidator<CreateAccountDto>
    {
        public CreateAccountDtoValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("E-mail is required")
                .Must(Email.IsValid)
                .WithMessage("Invalid e-mail");

            RuleFor(x => x.Password)
                .SetValidator(new PasswordValidation());

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .WithMessage("Birth date is required")
                .Must(x => x.Date <= DateTime.Today)
                .WithMessage("Birth date cannot be in the future");
        }
    }
}
