using System.ComponentModel.DataAnnotations;

namespace api.Validations
{
    public class JsonMinLength : MinLengthAttribute
    {
        public JsonMinLength(int length) : base(length)
        {
            ErrorMessage = "{0}: Minimum {1} characters.";
        }
    }
}