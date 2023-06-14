using api.Models.EntityModel.Addresses;
using api.Models.EntityModel.JuristicPersons;
using api.Models.EntityModel.NaturalPersons;

namespace api.Models.EntityModel.Persons
{
    public class Person
    {
        public long Id { get; set; }
        public string? Phone { get; set; }
        public string? Mobile { get; set; }
        public bool IsPatient { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsSuperAdmin { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public NaturalPerson? NaturalPerson { get; set; }
        public JuristicPerson? JuristicPerson { get; set; }
        public Address? Address { get; set; }

    }
}