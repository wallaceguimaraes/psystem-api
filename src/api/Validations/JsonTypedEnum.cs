using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace api.Validations
{
    public class JsonTypedEnum : ValidationAttribute
    {
        private Type _enumType;
        private object[] _forbiddenValues;

        public JsonTypedEnum(Type enumType, params object[] _forbidenValues)
        {
            _enumType = enumType;
            this._forbiddenValues = _forbidenValues;

            var values = Enum.GetNames(_enumType).ToList();

            foreach (var item in this._forbiddenValues)
            {
                values.Remove(item.ToString());
            }

            ErrorMessage = $"{{0}}: {string.Join("|", values)}";
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            if (value.GetType() == _enumType)
            {
                if (_forbiddenValues.Contains(value))
                {
                    return false;
                }

                foreach (var item in Enum.GetValues(_enumType))
                {
                    if (item.Equals(value)) return true;
                }
            }

            return false;
        }
    }
}
