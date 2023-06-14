using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace api.Validations
{
    public class JsonAny : ValidationAttribute
    {
        public JsonAny()
        {
            ErrorMessage = "{0}: At least one item.";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (value is ICollection collection)
            {
                return collection.Count > 0;
            }

            throw new ArgumentException("The value must be a ICollection type.");
        }
    }
}