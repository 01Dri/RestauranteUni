using FluentValidation;
using RaizesDoNordeste.Application.Validations;
using RaizesDoNordeste.Domain.Core.Login;

namespace RaizesDoNordeste.Application.UseCases.Login.Validations
{
    public sealed class LoginUseCaseDtoValidation : AbstractValidator<LoginDto>
    {

        public LoginUseCaseDtoValidation()
        {
            RuleFor(x => x.Email).SetValidator(new EmailValidation());
            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("A senha não pode ser nula ou vazia");

            RuleFor(x => x.RestaurantId)
                .NotEmpty()
                .WithMessage("O restaurante é obrigatório");
        }   
    }
}

