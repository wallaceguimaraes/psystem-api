using api.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace api.Validations
{
    public class JsonMaxLengthWithSpace : ValidationAttribute
    {
        private int _maxValue;
        private bool CheckLenghtIsValid(string text)
        {
            if ((text.Trim()).Length > _maxValue )
            {
                return false;
            }

            return true;
        }

        public JsonMaxLengthWithSpace(int length)
        {
            _maxValue = length;

            ErrorMessage = $"{{0}}: Maximum {length} characters without space.";
        }

        public override bool IsValid(object value)
        {
            var stringValue = value?.ToString();

            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return true;
            }

            return CheckLenghtIsValid(stringValue);
        }
    }
}