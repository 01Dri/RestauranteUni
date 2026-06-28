namespace RaizesDoNordeste.Domain.ValuesObjects
{
    public sealed class Address
    {
        public Address(
            string? street,
            string? number,
            string? district,
            string? city,
            string? state,
            string? zipCode,
            string? complement = null)
        {
            Street = Required(street, nameof(street));
            Number = Required(number, nameof(number));
            District = Required(district, nameof(district));
            City = Required(city, nameof(city));
            State = Required(state, nameof(state)).ToUpperInvariant();
            ZipCode = NormalizeZipCode(zipCode);
            Complement = string.IsNullOrWhiteSpace(complement) ? null : complement.Trim();
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string? Complement { get; private set; }

        private static string Required(string? value, string propertyName)
        {
            ArgumentException.ThrowIfNullOrEmpty(value, propertyName);
            ArgumentException.ThrowIfNullOrWhiteSpace(value, propertyName);

            return value.Trim();
        }

        private static string NormalizeZipCode(string? zipCode)
        {
            ArgumentException.ThrowIfNullOrEmpty(zipCode, nameof(zipCode));
            ArgumentException.ThrowIfNullOrWhiteSpace(zipCode, nameof(zipCode));

            var digits = new string(zipCode.Where(char.IsDigit).ToArray());
            if (digits.Length != 8)
            {
                throw new ArgumentException("Invalid zip code", nameof(zipCode));
            }

            return digits;
        }
    }
}

