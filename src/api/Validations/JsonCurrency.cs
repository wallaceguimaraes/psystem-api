using System;
using System.ComponentModel.DataAnnotations;

namespace api.Validations
{
    public class JsonCurrency : ValidationAttribute
    {
        private decimal _maxValue;

        public JsonCurrency() : this(999999) { }

        public JsonCurrency(double maxValue)
        {
            _maxValue = (decimal)maxValue;

            ErrorMessage = "{0}: Greater than or equal to zero and two decimal places.";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (value is decimal amount)
            {
                return amount >= 0 && amount <= _maxValue && decimal.Round(amount, 2) == amount;
            }

            throw new ArgumentException("This property must be a Decimal.");
        }
    }
}