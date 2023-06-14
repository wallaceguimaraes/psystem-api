using api.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace api.Validations
{
    public class JsonBankAccountNumber : ValidationAttribute
    {
        public JsonBankAccountNumber()
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

            return RegexExtensions.SafeIsMatch(stringValue, @"^[0-9]{3,13}-[0-9a-zA-Z]{1,2}$");
        }
    }
}