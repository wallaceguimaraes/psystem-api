using api.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace api.Validations
{
    public class JsonPhone: ValidationAttribute
    {
        public JsonPhone()
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

            return RegexExtensions.SafeIsMatch(stringValue, @"^\([1-9]{2}\) (?:[2-8][0-9]|9[1-9])[0-9]{2,3}\-[0-9]{4}$") || RegexExtensions.SafeIsMatch(stringValue, @"^0800( ?\d{3} ?\d{4})?$");
        }
    }
}