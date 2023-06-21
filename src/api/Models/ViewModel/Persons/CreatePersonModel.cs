using api.Models.EntityModel.Addresses;
using api.Models.EntityModel.BusinessTypes;
using api.Models.EntityModel.Cnaes;
using api.Models.EntityModel.JuristicPersons;
using api.Models.EntityModel.NaturalPersons;
using api.Models.EntityModel.Persons;
using api.Models.EntityModel.Users;
using api.Models.ViewModel.Addresses;
using api.Models.ViewModel.JuristicPersons;
using api.Models.ViewModel.NaturalPersons;
using api.Models.ViewModel.Users;
using api.Validations;
using Newtonsoft.Json;

namespace api.Models.ViewModel.Persons
{
    public class CreatePersonModel
    {
        [JsonProperty("phone")]
        public string? Phone { get; set; }

        [JsonProperty("mobile")]
        public string? Mobile { get; set; }

        [JsonProperty("naturalPerson"), JsonRequiredValidate]
        public NaturalPersonModel? NaturalPerson { get; set; }

        [JsonProperty("juristicPerson")]
        public JuristicPersonModel? JuristicPerson { get; set; }

        [JsonProperty("user")]
        public UserModel? User { get; set; }

        [JsonProperty("isPatient")]
        public bool IsPatient { get; set; }

        [JsonProperty("isEmployee")]
        public bool IsEmployee { get; set; }

        [JsonProperty("address"), JsonRequiredValidate]
        public AddressModel? Address { get; set; }

        public Person Map(long companyId)
        {
            var person = new Person
            {
                Phone = Phone,
                Mobile = Mobile,
                IsPatient = IsPatient,
                IsEmployee = IsEmployee,
                InactivatedOn = null,
                CompanyId = companyId,
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
                    TradeName = JuristicPerson.TradeName,
                    FullName = JuristicPerson.FullName,
                    TaxDocument = JuristicPerson.TaxDocument,
                    Cnae = new Cnae
                    {
                        Code = JuristicPerson.CnaeCode,
                        Name = JuristicPerson.CnaeDescription
                    },
                    BusinessType = new BusinessType
                    {
                        Name = JuristicPerson.BusinessName,
                        Acronym = JuristicPerson.BusinessAcronym
                    }
                }
                : null,
                Address = new Address
                {
                    CityId = Address.CityId,
                    StreetNumber = Address.StreetNumber,
                    Line1 = Address.Line1,
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