using api.Models.EntityModel.BusinessTypes;
using api.Models.EntityModel.Cnaes;
using api.Models.EntityModel.Persons;

namespace api.Models.EntityModel.JuristicPersons
{
    public class JuristicPerson
    {
        public long PersonId { get; set; }
        public int BusinessTypeId { get; set; }
        public string? TradeName { get; set; }
        public string? FullName { get; set; }
        public string? TaxDocument { get; set; }
        public int? CnaeCode { get; set; }
        public BusinessType? BusinessType { get; set; }
        public Cnae? Cnae { get; set; }
        public Person? Person { get; set; }


    }
}