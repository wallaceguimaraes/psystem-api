using api.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace api.Validations
{
    public class JsonHexadecimal : ValidationAttribute
    {
        public JsonHexadecimal()
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

            return RegexExtensions.SafeIsMatch(stringValue, @"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$");
        }
    }
}
