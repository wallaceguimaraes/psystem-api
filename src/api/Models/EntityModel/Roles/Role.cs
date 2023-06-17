using api.Models.EntityModel.Companies;
using api.Models.EntityModel.Persons;

namespace api.Models.EntityModel.Roles
{
    public class Role
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool Active { get; set; }
        public long? HolderId { get; set; }

        public long CompanyId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Person? Holder { get; set; }
        public Company? Company { get; set; }

    }
}