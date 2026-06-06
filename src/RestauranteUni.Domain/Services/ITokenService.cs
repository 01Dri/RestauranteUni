using System.Security.Claims;

namespace RestauranteUni.Domain.Services
{
    public interface ITokenService
    {
        string WriteToken<T>(T id, string sub, List<Claim> claims, DateTime? expiration = null);
    }
}
