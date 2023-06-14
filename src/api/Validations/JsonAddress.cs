using api.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace api.Validations
{
    public class JsonAddress : ValidationAttribute
    {
        public JsonAddress()
        {
            ErrorMessage = "{0}: Invalid address.";
        }

        public override bool IsValid(object value)
        {
            var stringValue = value?.ToString();

            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return true;
            }

            return RegexExtensions.SafeIsMatch(stringValue.NoAccents(), @"^[A-Za-z0-9'ºª°\.\-\s\,]{1,}(?: [a-zA-Z\/]+){0,2}$");
        }
    }
}