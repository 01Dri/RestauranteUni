using RestauranteUni.Domain.Utils;

namespace RestauranteUni.Application.Utils
{
    public sealed class Ecrypter : IEcrypter
    {
        public string HashPassword(string value)
        {
            ArgumentException.ThrowIfNullOrEmpty(value);
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            return BCrypt.Net.BCrypt.HashPassword(value);
        }
    }   
}
