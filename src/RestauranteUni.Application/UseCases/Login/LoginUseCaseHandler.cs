using System.Net;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RestauranteUni.Application.Extensions;
using RestauranteUni.Data;
using RestauranteUni.Domain;
using RestauranteUni.Domain.Login;
using RestauranteUni.Domain.UseCases;
using RestauranteUni.Domain.ValuesObjects;

namespace RestauranteUni.Application.UseCases.Login
{
    public sealed class LoginUseCaseHandler : IUseCaseHandler<LoginDto,  LoginResponseDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IValidator<LoginDto> _validator;
        public LoginUseCaseHandler(ApplicationDbContext context, IValidator<LoginDto> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<Result<LoginResponseDto>> HandleAsync(LoginDto parameter, CancellationToken cancellation = default)
        {
            var validation = await _validator.ValidateAsync(parameter, cancellation);
            if (validation.ContainsErrors())
            {
                var propertyName = validation.Errors.First().PropertyName!;
                return Result<LoginResponseDto>.Failure
                (
          [new Validation($"Invalid {propertyName}")]
                );
            } 
            var email = new Email(parameter.Email);
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Email == email, cancellation);
            if (account == null)
            {
                return Result<LoginResponseDto>.Failure
                (
          [new Validation("Invalid credentials")],
                    HttpStatusCode.Unauthorized
                );
            }


            throw new NotImplementedException();
        }
    }
}
