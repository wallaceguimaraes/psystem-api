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

        public bool Equals(Address? other)
        {
            if (other == null) return false;

            return District.Equals(other.District, StringComparison.InvariantCultureIgnoreCase) &&
                Line1.Equals(other.Line1, StringComparison.InvariantCultureIgnoreCase) &&
                StreetNumber.Equals(other.StreetNumber, StringComparison.InvariantCultureIgnoreCase) &&
                ZipCode.Equals(other.ZipCode, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}