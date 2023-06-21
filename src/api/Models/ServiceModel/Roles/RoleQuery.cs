using api.Models.EntityModel.Roles;

namespace api.Models.ServiceModel.Roles
{
    public static class RoleQuery
    {

        public static IQueryable<Role> WhereCompanyId(this IQueryable<Role> roles, long companyId)
        {
            return roles.Where(role => role.CompanyId == companyId);
        }
        public static IQueryable<Role> WhereName(this IQueryable<Role> roles, string description)
        {
            return roles.Where(role => role.Name == description);
        }

        public static IQueryable<Role> WhereId(this IQueryable<Role> roles, long id)
        {
            return roles.Where(role => role.Id == id);
        }

        public static IQueryable<Role> IncludeRole(this IQueryable<Role> roles, long id)
        {
            return roles.Where(role => role.Id == id);
        }


    }
}