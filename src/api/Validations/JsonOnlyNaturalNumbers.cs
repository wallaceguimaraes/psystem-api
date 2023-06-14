using api.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace api.Validations
{
    public class JsonOnlyNaturalNumbers : ValidationAttribute
    {
        public JsonOnlyNaturalNumbers()
        {
            ErrorMessage = "{0}: Only natural numbers.";
        }

        public override bool IsValid(object value)
        {
            var stringValue = value?.ToString();

            if (stringValue == null)
            {
                return true;
            }

            return RegexExtensions.SafeIsMatch(stringValue, @"^[0-9]+$");
        }
    }
}
