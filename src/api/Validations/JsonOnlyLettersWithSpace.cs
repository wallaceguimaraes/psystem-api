using api.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace api.Validations
{
    public class JsonOnlyLettersWithSpace : ValidationAttribute
    {
        public JsonOnlyLettersWithSpace()
        {
            ErrorMessage = "{0}: Cannot have numbers and special characters.";
        }

        public override bool IsValid(object value)
        {
            var stringValue = value?.ToString();

            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return true;
            }

            return RegexExtensions.SafeIsMatch(stringValue.NoAccents(), @"^[a-zA-Z_ ]*$");
        }
    }
}