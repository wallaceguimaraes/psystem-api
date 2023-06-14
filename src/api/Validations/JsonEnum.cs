using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace api.Validations
{
    public class JsonEnum : ValidationAttribute
    {
        private readonly string[] _values;

        public JsonEnum(params string[] values)
        {
            _values = values;
            ErrorMessage = $"{{0}}: {string.Join("|", values)}";
        }

        public JsonEnum(Type enumType)
        {
            _values = Enum.GetNames(enumType).ToArray();
            ErrorMessage = $"{{0}}: {string.Join("|", _values)}";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var stringValue = value.ToString();
            var ret = _values.Any(allowedValue => string.Equals(allowedValue, stringValue, StringComparison.OrdinalIgnoreCase));
            return ret;
        }
    }
}