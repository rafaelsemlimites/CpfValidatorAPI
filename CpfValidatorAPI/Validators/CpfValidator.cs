using System.Text.RegularExpressions;

namespace CpfValidatorAPI.Validators
{
    public static class CpfValidator
    {
        private static readonly Regex DigitsOnly = new(@"^\d{11}$");

        public static bool IsValid(string? cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf)) return false;

            // Remove caracteres não numéricos
            cpf = Regex.Replace(cpf, @"\D", "");

            // Verifica se contém exatamente 11 dígitos numéricos
            if (!DigitsOnly.IsMatch(cpf)) return false;

            // Verifica se todos os dígitos são iguais
            if (cpf.Distinct().Count() == 1) return false;

            // Calcula os dígitos verificadores
            string calculatedCpf = cpf[..9];
            calculatedCpf += CalculateVerifierDigit(calculatedCpf);
            calculatedCpf += CalculateVerifierDigit(calculatedCpf);

            return cpf == calculatedCpf;
        }

        private static char CalculateVerifierDigit(string cpf)
        {
            int sum = 0;
            for (int i = 0; i < cpf.Length; i++)
            {
                sum += (cpf[i] - '0') * (cpf.Length + 1 - i);
            }

            int remainder = (sum * 10) % 11;
            return (remainder == 10 ? '0' : (char)(remainder + '0'));
        }
    }
}
