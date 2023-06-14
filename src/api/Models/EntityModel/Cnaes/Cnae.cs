using api.Models.EntityModel.JuristicPersons;

namespace api.Models.EntityModel.Cnaes
{
    public class Cnae
    {
        public int Code { get; set; }
        public string? Name { get; set; }
        public ICollection<JuristicPerson>? JuristicPersons { get; set; }

    }
}