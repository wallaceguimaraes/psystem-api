using api.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace api.Validations
{
    public class JsonCnpj : ValidationAttribute
    {
        private bool CheckNumberIsValid(string cnpj)
        {
            var multiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplier2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.OnlyNumbers();

            if (cnpj.Distinct().Count() == 1 || cnpj.Length != 14)
            {
                return false;
            }

            var tempCnpj = cnpj.Substring(0, 12);
            var sum = 0;

            for (int i = 0; i < 12; i++)
            {
                sum += int.Parse(tempCnpj[i].ToString()) * multiplier1[i];
            }

            var rest = (sum % 11);
            rest = rest < 2 ? 0 : 11 - rest;

            var digit = rest.ToString();
            tempCnpj = tempCnpj + digit;
            sum = 0;

            for (int i = 0; i < 13; i++)
            {
                sum += int.Parse(tempCnpj[i].ToString()) * multiplier2[i];
            }

            rest = (sum % 11);
            rest = rest < 2 ? 0 : 11 - rest;

            digit = digit + rest.ToString();

            return cnpj.EndsWith(digit);
        }

        public JsonCnpj()
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

            if (!RegexExtensions.SafeIsMatch(stringValue, @"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$"))
            {
                return false;
            }

            return CheckNumberIsValid(stringValue);
        }
    }
}