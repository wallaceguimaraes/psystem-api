using System.ComponentModel.DataAnnotations;

namespace api.Validations
{
    public class JsonTaxDocument : ValidationAttribute
    {
        public JsonTaxDocument()
        {
            ErrorMessage = "{0}: Invalid.";
        }

        public override bool IsValid(object value)
        {
            return new JsonCpf().IsValid(value) || new JsonCnpj().IsValid(value);
        }
    }
}