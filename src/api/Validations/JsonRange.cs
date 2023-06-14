using System.ComponentModel.DataAnnotations;

namespace api.Validations
{
    public class JsonRange : RangeAttribute
    {
        public JsonRange(int min, int max) : base(min, max)
        {
            ErrorMessage = "{0}: Between {1} and {2}.";
        }
    }
}