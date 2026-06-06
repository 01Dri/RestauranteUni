namespace RestauranteUni.Domain.ValuesObjects
{
    public class Email : IEquatable<Email>
    {
        public string Value { get;}

        public Email(string? value)
        {
            ArgumentException.ThrowIfNullOrEmpty(value);
            ArgumentException.ThrowIfNullOrWhiteSpace(value);

            if (!IsValid(value))
            {
                throw new ArgumentException("Invalid e-mail");
            }
            Value = value.ToLowerInvariant();
        }

        public static bool IsValid(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email
                       && addr.Host.Contains('.');
            }
            catch
            {
                return false;
            }
        }

        public bool Equals(Email? other)
        {
            return other is not null && Value == other.Value;
        }

        public override bool Equals(object? obj)
        {
            return obj is Email email && Equals(email);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(Email? left, Email? right)
        {
            return EqualityComparer<Email>.Default.Equals(left, right);
        }

        public static bool operator !=(Email? left, Email? right)
        {
            return !(left == right);
        }
    }
}
