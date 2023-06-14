using api.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace api.Validations
{
    public class JsonOnlyLetters : ValidationAttribute
    {
        public JsonOnlyLetters()
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

            return RegexExtensions.SafeIsMatch(stringValue.NoAccents(), @"^[a-zA-Z]+[a-zA-Z'.\s]*$");
        }
    }
}