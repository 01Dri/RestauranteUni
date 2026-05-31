using RestauranteUni.Domain.UseCases;

namespace RestauranteUni.Domain.Account.DTO
{
    public record CreateAccountDto : IRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required DateTime BirthDate { get; set; }

    }
}
