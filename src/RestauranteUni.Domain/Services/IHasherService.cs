namespace RestauranteUni.Domain.Services
{
    public interface IHasherService
    {
        string HashPassword(string value);
        bool VerifyPassword(string value, string hashedValue);
    }
}
