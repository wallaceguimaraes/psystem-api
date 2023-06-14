using api.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace api.Validations
{
    public class JsonMinWordLength: ValidationAttribute
    {
        int _min;

        public JsonMinWordLength(int min)
        {
            ErrorMessage = $"{{0}}: Minimum {min} characters for each word.";
            this._min = min;
        }

        public override bool IsValid(object value)
        {
            var stringValue = value?.ToString();

            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return true;
            }

            return !stringValue.Words().Any(word => word.Length < _min);
        }
    }
}