using api.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace api.Validations
{
    public class JsonCpf : ValidationAttribute
    {
        private bool CheckNumberIsValid(string cpf)
        {
            var multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.OnlyNumbers();

            if (cpf.Distinct().Count() == 1 || cpf.Length != 11)
            {
                return false;
            }

            var tempCpf = cpf.Substring(0, 9);
            var sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];
            }

            var rest = sum % 11;
            rest = rest < 2 ? 0 : 11 - rest;

            var digit = rest.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];
            }

            rest = sum % 11;
            rest = rest < 2 ? 0 : 11 - rest;

            digit = digit + rest.ToString();

            return cpf.EndsWith(digit);
        }

        public JsonCpf()
        {
            ErrorMessage = "{0}: Invalid.";
        }

        public override bool IsValid(object value)
        {
            var stringValue = value?.ToString();

            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return true;
            }

            if (!RegexExtensions.SafeIsMatch(stringValue, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$"))
            {
                return false;
            }

            return CheckNumberIsValid(stringValue);
        }
    }
}