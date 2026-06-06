namespace RestauranteUni.Domain.ValuesObjects
{
    public sealed class Cnpj
    {
        public string Value { get; }

        public Cnpj(string? value)
        {
            ArgumentException.ThrowIfNullOrEmpty(value);
            ArgumentException.ThrowIfNullOrWhiteSpace(value);

            var digits = OnlyDigits(value);
            if (!IsValid(digits))
            {
                throw new ArgumentException("Invalid CNPJ");
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
            if (digits.Length != 14 || digits.All(x => x == digits[0]))
            {
                return false;
            }

            return CalculateDigit(digits, [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2]) == digits[12] - '0'
                && CalculateDigit(digits, [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2]) == digits[13] - '0';
        }

        private static int CalculateDigit(string digits, int[] weights)
        {
            var sum = weights.Select((weight, index) => (digits[index] - '0') * weight).Sum();
            var remainder = sum % 11;
            return remainder < 2 ? 0 : 11 - remainder;
        }

        private static string OnlyDigits(string value)
        {
            return new string(value.Where(char.IsDigit).ToArray());
        }
    }
}
