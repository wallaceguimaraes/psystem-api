using System;
using System.ComponentModel.DataAnnotations;

namespace api.Validations
{
    public class JsonPastDate : ValidationAttribute
    {
        public JsonPastDate()
        {
            ErrorMessage = "{0}: The date must be in the past.";
        }
        public override bool IsValid(object value)
        {
            if(value == null) return true;
            if (value is DateTime date)
            {
                return date.CompareTo(DateTime.Now) < 0;
            }

            return false;
        }
    }
}