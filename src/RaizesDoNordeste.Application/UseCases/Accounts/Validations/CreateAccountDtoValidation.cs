using FluentValidation;
using RaizesDoNordeste.Application.Validations;
using RaizesDoNordeste.Domain.Core.Accounts.DTO;

namespace RaizesDoNordeste.Application.UseCases.Accounts.Validations
{
    public sealed class CreateAccountDtoValidation : AbstractValidator<CreateAccountDto>
    {
        public CreateAccountDtoValidation()
        {
            RuleFor(x => x.Email).SetValidator(new EmailValidation());

            RuleFor(x => x.Password)
                .SetValidator(new PasswordValidation());

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .WithMessage("A data de nascimento é obrigatória")
                .Must(x => x.Date <= DateTime.Today)
                .WithMessage("A data de nascimento não pode ser no futuro");
        }
    }
}

