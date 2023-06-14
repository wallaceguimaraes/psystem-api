using api.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace api.Validations
{
    public class JsonPasswordAttribute : ValidationAttribute
    {
        public JsonPasswordAttribute()
        {
            ErrorMessage = "{0}: Does not meet the safety criteria.";
        }

        public override bool IsValid(object value)
        {
            var stringValue = value?.ToString();

            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return true;
            }

            return RegexExtensions.SafeIsMatch(stringValue, @"^(?=^.{8,}$)((?=.*\d)(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$");
        }

    }
}
