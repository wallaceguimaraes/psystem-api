using System.ComponentModel.DataAnnotations;

namespace api.Models.ViewModel.Addresses
{
    public class AddressModel
    {

        [Display(Name = "cityId")]
        public int CityId { get; set; }

        [Display(Name = "district")]
        public string? District { get; set; }

        [Display(Name = "line1")]
        public string? Line1 { get; set; }

        [Display(Name = "line2")]
        public string? Line2 { get; set; }

        [Display(Name = "streetNumber")]
        public string? StreetNumber { get; set; }

        [Display(Name = "zipCode")]
        public string? ZipCode { get; set; }

        [Display(Name = "city")]
        public string? City { get; set; }

    }
}