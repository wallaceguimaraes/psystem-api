using System.ComponentModel.DataAnnotations;

namespace api.Validations
{
    public class JsonOnlyNumbers : RegularExpressionAttribute
    {
        public JsonOnlyNumbers() : base(@"^\d*$")
        {
            ErrorMessage = "{0}: Only numbers.";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            return base.IsValid(value);
        }
    }
}