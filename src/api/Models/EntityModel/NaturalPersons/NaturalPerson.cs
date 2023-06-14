using api.Models.EntityModel.Persons;

namespace api.Models.EntityModel.NaturalPersons
{
    public class NaturalPerson
    {
        public long PersonId { get; set; }
        public string? FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Gender { get; set; }
        public string? TaxDocument { get; set; }
        public Person? Person { get; set; }

    }
}