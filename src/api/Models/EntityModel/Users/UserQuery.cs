

using Microsoft.EntityFrameworkCore;

namespace api.Models.EntityModel.Users
{
    public static class UserQuery
    {
        public static IQueryable<User> WherePersonId(this IQueryable<User> users, long personId)
        {
            return users.Where(user => user.PersonId == personId);
        }
        public static IQueryable<User> IncludePerson(this IQueryable<User> users)
        {
            return users
                .Include(user => user.Person)
                .ThenInclude(person => person.NaturalPerson)
                .Include(user => user.Person)
                .ThenInclude(person => person.JuristicPerson);
        }

        public static IQueryable<User> IncludeRoles(this IQueryable<User> users)
        {
            return users
                .Include(user => user.RoleUser)
                .ThenInclude(role => role.Role);
        }
        public static IQueryable<User> IncludeAddress(this IQueryable<User> users)
        {
            return users
                .Include(user => user.Person)
                .ThenInclude(person => person.Address);
        }

        public static IQueryable<User> WhereEmail(this IQueryable<User> users, string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return users;
            }

            return users.Where(user => user.Email == email);
        }
    }
}