using api.Models.EntityModel.Persons;
using api.Models.EntityModel.Users;

namespace api.Models.IntegrationModel.Model
{
    public class WhoAmI
    {
        public Person? Person { get; set; }
        public User? User { get; set; }
        public bool AccessGranted { get; set; }
        public bool AccessedBySuperAdmin { get; set; }
        public bool AccessedByEmployee { get; set; }

        public WhoAmI()
        {

        }
    }
}