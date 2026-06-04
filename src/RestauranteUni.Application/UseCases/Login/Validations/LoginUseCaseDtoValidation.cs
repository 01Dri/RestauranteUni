using FluentValidation;
using RestauranteUni.Application.Utils;
using RestauranteUni.Domain.Login;

namespace RestauranteUni.Application.UseCases.Login.Validations
{
    public sealed class LoginUseCaseDtoValidation : AbstractValidator<LoginDto>
    {

        public LoginUseCaseDtoValidation()
        {
            RuleFor(x => x.Email).SetValidator(new EmailValidation());
            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Password can't be null or empty");
        }   
    }
}
