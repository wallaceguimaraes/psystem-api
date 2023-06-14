using api.Models.EntityModel.Persons;

namespace api.Models.EntityModel.Addresses
{
    public class Address
    {
        public long PersonId { get; set; }
        public int CityId { get; set; }
        public string? District { get; set; }
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? StreetNumber { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public Person? Person { get; set; }
    }
}