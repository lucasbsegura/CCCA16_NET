namespace CCCA16_NET.Domain
{
    public class ValidateCpf
    {
        public int FACTOR_FIRST_DIGIT { get { return 10; } }
        public int FACTOR_SECOND_DIGIT { get { return 11; } }

        public bool Validate(string RawCpf)
        {
            if (string.IsNullOrEmpty(RawCpf)) return false;
            var cpf = RemoveNonDigits(RawCpf);
            if (!IsValidLength(cpf)) return false;
            if (AllDigitsEqual(cpf)) return false;
            var firstDigit = CalculateDigit(cpf, FACTOR_FIRST_DIGIT);
            var secondDigit = CalculateDigit(cpf, FACTOR_SECOND_DIGIT);
            return ExtractDigit(cpf) == Convert.ToInt32(string.Format("{0}{1}", firstDigit, secondDigit));
        }
        private string RemoveNonDigits(string cpf)
        {
            return cpf.Replace(".", "").Replace("-", "").Replace("/", "");
        }
        private bool IsValidLength(string cpf)
        {
            return cpf.Length == 11;
        }
        private bool AllDigitsEqual(string cpf)
        {
            return cpf.Distinct().Count() == 1;
        }
        private int CalculateDigit(string cpf, int factor)
        {
            var total = 0;
            foreach (var digit in cpf)
            {
                if (factor > 1) total += int.Parse(digit.ToString()) * factor--;
            }
            var remainder = total % 11;
            return (remainder < 2) ? 0 : 11 - remainder;
        }
        private int ExtractDigit(string cpf)
        {
            return Convert.ToInt32(cpf.Substring(cpf.Length - 2));
        }
    }
}
