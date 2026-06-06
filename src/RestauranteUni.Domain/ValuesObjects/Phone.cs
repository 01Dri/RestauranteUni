namespace RestauranteUni.Domain.ValuesObjects
{
    public sealed class Phone
    {
        public string Value { get; }

        public Phone(string? value)
        {
            ArgumentException.ThrowIfNullOrEmpty(value);
            ArgumentException.ThrowIfNullOrWhiteSpace(value);

            var digits = OnlyDigits(value);
            if (!IsValid(digits))
            {
                throw new ArgumentException("Invalid phone");
            }

            Value = digits;
        }

        public static bool IsValid(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            var digits = OnlyDigits(value);
            return digits.Length is 10 or 11;
        }

        private static string OnlyDigits(string value)
        {
            return new string(value.Where(char.IsDigit).ToArray());
        }
    }
}
