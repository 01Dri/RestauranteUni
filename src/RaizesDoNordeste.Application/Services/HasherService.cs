using RaizesDoNordeste.Domain.Services;

namespace RaizesDoNordeste.Application.Services
{
    public sealed class HasherService : IHasherService
    {
        public string HashPassword(string value)
        {
            ArgumentException.ThrowIfNullOrEmpty(value);
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            return BCrypt.Net.BCrypt.HashPassword(value);
        }

        public bool VerifyPassword(string value, string hashedValue)
        {
            ArgumentException.ThrowIfNullOrEmpty(value);
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            return BCrypt.Net.BCrypt.Verify(value, hashedValue);
        }

    }   
}

