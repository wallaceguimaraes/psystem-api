using api.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace api.Validations
{
    public class JsonMinWord : ValidationAttribute
    {
        int _min;

        public JsonMinWord(int min)
        {
            ErrorMessage = $"{{0}}: At least {min} words.";
            this._min = min;
        }

        public override bool IsValid(object value)
        {
            var stringValue = value?.ToString();

            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return true;
            }

            return RegexExtensions.SafeIsMatch(stringValue.NoAccents(), @"^(?:(?:^| )\S+ *){" + _min + ",}$");
        }
    }
}