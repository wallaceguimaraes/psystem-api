using api.Models.EntityModel.Persons;
using api.Models.EntityModel.Roles;

namespace api.Models.EntityModel.Users
{
    public class User
    {
        public long PersonId { get; set; }
        public long RoleId { get; set; }
        public bool Active { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }
        public DateTime CreatedAt { get; set; }
        public Person? Person { get; set; }
        public Role? Role { get; set; }
    }
}