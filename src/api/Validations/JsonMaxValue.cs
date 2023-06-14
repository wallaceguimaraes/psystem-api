using System;
using System.ComponentModel.DataAnnotations;

namespace api.Validations
{
    public class JsonMaxValue : ValidationAttribute
    {
        private int _max;

        public JsonMaxValue(int max)
        {
            _max = max;

            ErrorMessage = $"{{0}}: Maximum {max}.";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            
            if (value is int intValue)
            {
                return intValue <= _max;
            }

            throw new ArgumentException("The value must be a numeric type.");
        }
    }
}