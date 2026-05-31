using FluentValidation;
using RestauranteUni.Application.Extensions;
using RestauranteUni.Data;
using RestauranteUni.Domain;
using RestauranteUni.Domain.Account.DTO;
using RestauranteUni.Domain.UseCases;
using RestauranteUni.Domain.ValuesObjects;

namespace RestauranteUni.Application.UseCases.Account
{
    public class CreateAccountUseCaseHandler : IUseCaseHandler<CreateAccountDto, CreateAccountResponseDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IValidator<CreateAccountDto> _validator;

        public CreateAccountUseCaseHandler(ApplicationDbContext context, IValidator<CreateAccountDto> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<Result<CreateAccountResponseDto>> HandleAsync(CreateAccountDto parameter, CancellationToken cancellation = default)
        {
            var validations = await _validator.ValidateAsync(parameter, cancellation);
            if (validations != null && validations.Errors.Count > 0)
            {
                return validations.ToResultFailure<CreateAccountResponseDto>();
            }

            var email = new Email(parameter.Email);
            var account = new Domain.Account.Account()
            {
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(parameter.Password),
            };

            await _context.Accounts.AddAsync(account, cancellation);
            await _context.SaveChangesAsync(cancellation);
            return Result<CreateAccountResponseDto>.Success(new CreateAccountResponseDto()
            {
                Id = account.Id,
                Email = account.Email,
            });

        }
    }
}
