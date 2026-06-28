using FluentValidation;
using RaizesDoNordeste.Domain.ValuesObjects;

namespace RaizesDoNordeste.Application.Validations
{
    internal sealed class EmailValidation : AbstractValidator<string>
    {
        public EmailValidation()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("O e-mail é obrigatório")
                .Must(Email.IsValid)
                .WithMessage("E-mail inválido");
        }
    }
}

