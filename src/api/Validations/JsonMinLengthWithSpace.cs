using api.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace api.Validations
{
    public class JsonMinLengthWithSpace : ValidationAttribute
    {
        private int _minValue;
        private bool CheckLenghtIsValid(string text)
        {

            if ((text.Trim()).Length < _minValue)
            {
                return false;
            }

            return true;
        }

        public JsonMinLengthWithSpace(int length)
        {
            _minValue = length;

            ErrorMessage = $"{{0}}: Minimum {length} characters without space.";

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