using api.Models.EntityModel.Persons;
using api.Models.EntityModel.Roles;

namespace api.Models.EntityModel.Companies
{
    public class Company
    {
        public long Id { get; set; }
        public string? TradeName { get; set; }
        public string? FullName { get; set; }
        public string? TaxDocument { get; set; }
        public string? CnaeCode { get; set; }
        public string? BusinessTypeName { get; set; }
        public string? BusinessTypeAcronym { get; set; }
        public DateTime SystemImplementation { get; set; } = DateTime.Now;
        public ICollection<Role>? Roles { get; set; }
        public ICollection<Person>? People { get; set; }


    }
}