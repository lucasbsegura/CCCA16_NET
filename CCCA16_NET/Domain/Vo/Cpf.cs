namespace CCCA16_NET.Domain.Vo
{
    public class Cpf
    {
        private int FACTOR_FIRST_DIGIT { get { return 10; } }
        private int FACTOR_SECOND_DIGIT { get { return 11; } }
        private string Value { get; set; }

        public Cpf(string cpf)
        {
            if (!this.Validate(cpf)) throw new Exception("Invalid Cpf");
            this.Value = cpf;
        }

        private bool Validate(string RawCpf)
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

        public string GetValue()
        {
            return this.Value;
        }
    }
}
