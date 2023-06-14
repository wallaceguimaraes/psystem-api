using System.ComponentModel.DataAnnotations;

namespace api.Validations
{
    public class JsonUrl : RegularExpressionAttribute
    {
        public JsonUrl() : base(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}(\.[a-z]{2,6})?\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)")
        {
            ErrorMessage = "{0}: Invalid URL.";
        }
    }
}