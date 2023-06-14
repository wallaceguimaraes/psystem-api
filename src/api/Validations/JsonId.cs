using api.Extensions;
using System.ComponentModel.DataAnnotations;

namespace api.Validations
{
    public class JsonId : ValidationAttribute
    {
        public JsonId()
        {
            ErrorMessage = "{0}: Invalid.";
        }

        public override bool IsValid(object value)
        {
            var stringValue = value?.ToString();

            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return true;
            }

            return stringValue.ToLongId() > 0;
        }
    }
}
