using System;
using System.ComponentModel.DataAnnotations;

namespace api.Validations
{
    public class JsonPrecision : ValidationAttribute
    {
        private int _precision;
        private int _scale;

        public JsonPrecision(int precision)
        {
            _precision = precision;

            ErrorMessage = $"{{0}}: Precision {precision}.";
        }

        public JsonPrecision(int precision, int scale)
        {
            _precision = precision;
            _scale = scale;

            ErrorMessage = $"{{0}}: Precision {precision} and scale {scale}.";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            decimal number;

            if (decimal.TryParse(value.ToString(), out number))
            {
                var validPrecision = number % (decimal)Math.Pow(10, _precision - _scale) == number;
                var validScale = decimal.Round(number, _scale) == number;

                return validPrecision && validScale;
            }

            return false;
        }
    }
}