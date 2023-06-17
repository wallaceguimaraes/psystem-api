using System.ComponentModel.DataAnnotations;
using api.Models.EntityModel.Addresses;
using api.Models.EntityModel.JuristicPersons;
using api.Models.EntityModel.NaturalPersons;
using api.Models.EntityModel.Persons;
using api.Models.EntityModel.Users;
using api.Models.ViewModel.Addresses;
using api.Models.ViewModel.JuristicPersons;
using api.Models.ViewModel.NaturalPersons;
using api.Models.ViewModel.Users;

namespace api.Models.ViewModel.Persons
{
    public class CreatePersonModel
    {
        [Display(Name = "phone")]
        public string? Phone { get; set; }

        [Display(Name = "mobile")]
        public string? Mobile { get; set; }

        [Display(Name = "naturalPerson")]
        public NaturalPersonModel? NaturalPerson { get; set; }

        [Display(Name = "juristicPerson")]
        public JuristicPersonModel? JuristicPerson { get; set; }

        [Display(Name = "user")]
        public UserModel? User { get; set; }

        [Display(Name = "isPatient")]
        public bool IsPatient { get; set; }

        [Display(Name = "isEmployee")]
        public bool IsEmployee { get; set; }

        [Display(Name = "address")]
        public AddressModel? Address { get; set; }

        public Person Map()
        {
            var person = new Person
            {
                Phone = Phone,
                Mobile = Mobile,
                IsPatient = IsPatient,
                IsEmployee = IsEmployee,
                User = new User
                {
                    Email = User.Email,
                    Password = User.Password,
                    RoleId = User.RoleId
                },
                NaturalPerson = NaturalPerson != null ?
                                new NaturalPerson
                                {
                                    FullName = NaturalPerson.FullName,
                                    BirthDate = NaturalPerson.BirthDate,
                                    Gender = NaturalPerson.Gender,
                                    TaxDocument = NaturalPerson.TaxDocument
                                }
                                : null,
                JuristicPerson = JuristicPerson != null ?
                new JuristicPerson
                {
                    BusinessTypeId = JuristicPerson.BusinessTypeId,
                    TradeName = JuristicPerson.TradeName,
                    FullName = JuristicPerson.FullName,
                    TaxDocument = JuristicPerson.TaxDocument,
                    CnaeCode = JuristicPerson.CnaeCode
                }
                : null,
                Address = new Address
                {
                    CityId = Address.CityId,
                    StreetNumber = Address.StreetNumber,
                    Line2 = Address.Line2,
                    District = Address.District,
                    ZipCode = Address.ZipCode,
                    City = Address.City
                }

            };

            return person;
        }
    }
}