using System;
using System.ComponentModel.DataAnnotations;

namespace api.Validations
{
    public class JsonMinValue : ValidationAttribute
    {
        private object _min;

        public JsonMinValue(object min)
        {
            _min = min;

            ErrorMessage = $"{{0}}: Minimum {min}.";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            
            if (value is int intValue)
            {
                return intValue >= (int)_min;
            }

            if (value is decimal floatValue)
            {
                return Convert.ToSingle(floatValue) >= Convert.ToSingle(_min);
            }


            throw new ArgumentException("The value must be a numeric type.");
        }
    }
}