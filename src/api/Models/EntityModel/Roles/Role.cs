using api.Models.EntityModel.Companies;
using api.Models.EntityModel.RoleUsers;

namespace api.Models.EntityModel.Roles
{
    public class Role
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool Active { get; set; }
        public long? CompanyId { get; set; }
        public Company? Company { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<RoleUser>? RoleUsers { get; set; }

    }
}