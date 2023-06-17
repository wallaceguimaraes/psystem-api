using api.Models.EntityModel.Persons;
using api.Models.EntityModel.Roles;

namespace api.Models.EntityModel.RoleUsers
{
    public class RoleUser
    {
        public long Id { get; set; }
        public long? HolderId { get; set; }
        public long RoleId { get; set; }
        public Person? Holder { get; set; }
        public Role? Role { get; set; }

    }
}