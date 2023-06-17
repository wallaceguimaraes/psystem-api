using api.Models.EntityModel.Companies;

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
    }
}