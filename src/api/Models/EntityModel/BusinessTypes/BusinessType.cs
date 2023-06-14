using api.Models.EntityModel.JuristicPersons;

namespace api.Models.EntityModel.BusinessTypes
{
    public class BusinessType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Acronym { get; set; }
        public string? AdiqCode { get; set; }
        public ICollection<JuristicPerson>? JuristicPersons { get; set; }


    }
}