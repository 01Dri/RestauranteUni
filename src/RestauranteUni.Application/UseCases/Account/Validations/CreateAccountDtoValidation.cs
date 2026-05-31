using FluentValidation;
using RestauranteUni.Domain.Account.DTO;

namespace RestauranteUni.Application.UseCases.Account.Validations
{
    public class CreateAccountDtoValidation : AbstractValidator<CreateAccountDto>
    {
        public CreateAccountDtoValidation()
        {
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Invalid e-mail");
        }
    }
}
