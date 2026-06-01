namespace RestauranteUni.Domain.Utils
{
    public interface IEcrypter
    {
        string HashPassword(string value);
    }
}
