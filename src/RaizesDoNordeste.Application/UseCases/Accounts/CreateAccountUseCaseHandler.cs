using FluentValidation;
using RaizesDoNordeste.Application.Extensions;
using RaizesDoNordeste.Data;
using RaizesDoNordeste.Domain.Core.Accounts;
using RaizesDoNordeste.Domain.Core.Accounts.DTO;
using RaizesDoNordeste.Domain.Core.Accounts.Roles;
using RaizesDoNordeste.Domain.Services;
using RaizesDoNordeste.Domain.UseCases;
using RaizesDoNordeste.Domain.ValuesObjects;

namespace RaizesDoNordeste.Application.UseCases.Accounts
{
    public sealed class CreateAccountUseCaseHandler : IUseCaseHandler<CreateAccountDto, CreateAccountUseCaseResponseDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IValidator<CreateAccountDto> _validator;
        private readonly IHasherService _hasherService;

        public CreateAccountUseCaseHandler(ApplicationDbContext context, IValidator<CreateAccountDto> validator, IHasherService hasherService)
        {
            _context = context;
            _validator = validator;
            _hasherService = hasherService;
        }

        public async Task<Result<CreateAccountUseCaseResponseDto>> HandleAsync(CreateAccountDto parameter, CancellationToken cancellation = default)
        {
            var validation = await _validator.ValidateAsync(parameter, cancellation);
            if (validation.ContainsErrors())
            {
                return validation.ToResultFailure<CreateAccountUseCaseResponseDto>();
            }

            var email = new Email(parameter.Email);
            var account = new Account()
            {
                Email = email,
                Password = _hasherService.HashPassword(parameter.Password),
                RoleAccounts =
                [
                    RoleAccount.Create(RoleType.Customer, RoleStatus.Enable)
                ]
            };

            await _context.Accounts.AddAsync(account, cancellation);
            await _context.SaveChangesAsync(cancellation);
            return Result<CreateAccountUseCaseResponseDto>.Success(new CreateAccountUseCaseResponseDto()
            {
                Id = account.Id,
                Email = account.Email,
                Roles = account.RoleAccounts
                    .Where(x => x.RoleId.HasValue)
                    .Select(x => x.RoleId!.Value)
                    .ToList()
            });

        }
    }
}

