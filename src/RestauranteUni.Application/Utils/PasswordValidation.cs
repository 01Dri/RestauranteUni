using FluentValidation;

namespace RestauranteUni.Application.Utils
{
    public class PasswordValidation : AbstractValidator<string>
    {
        public PasswordValidation()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("Password is required")
                .MinimumLength(8)
                .WithMessage("Password must have at least 8 characters")
                .Matches("[A-Z]")
                .WithMessage("Password must contain at least one uppercase letter")
                .Matches("[a-z]")
                .WithMessage("Password must contain at least one lowercase letter")
                .Matches("[0-9]")
                .WithMessage("Password must contain at least one number");
        }
    }
}
