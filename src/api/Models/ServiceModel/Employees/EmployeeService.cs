using api.Data.Context;
using api.Extensions;
using api.Infrastructure.Security;
using api.Models.EntityModel.Persons;
using api.Models.EntityModel.Users;
using api.Models.ServiceModel.Roles;
using Microsoft.EntityFrameworkCore;

namespace api.Models.ServiceModel.Employees
{
    public class EmployeeService
    {
        private readonly ApiDbContext? _dbContext;
        private readonly ILogger<EmployeeService>? _logger;
        public EmployeeService(ApiDbContext dbContext, ILogger<EmployeeService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Person Person { get; private set; }
        public bool EmployeeRegisterError { get; private set; }
        public bool EmployeeNotFound { get; private set; }

        public async Task<bool> CreateEmployee(Person person)
        {
            if (person == null)
                return !(EmployeeRegisterError = true);

            var roleExists = await _dbContext.Roles.WhereCompanyId(person.CompanyId)
                                                    .WhereId(person.User.RoleId)
                                                    .AnyAsync();

            if (!roleExists)
                return !(EmployeeRegisterError = true);

            var cnae = await _dbContext.Cnaes.Where(cnae => cnae.Code == person.JuristicPerson.Cnae.Code)
                                             .SingleOrDefaultAsync();
            if (cnae != null)
                person.JuristicPerson.Cnae = cnae;

            var salt = new Salt().ToString();
            person.User.Salt = salt;
            person.User.Password = person.User.Password.Encrypt(salt);

            try
            {
                _dbContext.Persons.Add(person);
                await _dbContext.SaveChangesAsync();

            }
            catch (System.Exception ex)
            {
                var error = ex;

                return !(EmployeeRegisterError = true);
            }
            Person = person;
            return true;
        }


        public async Task<User?> FindEmployeeAuthenticated(string personId)
        {
            if (String.IsNullOrEmpty(personId))
                return null;

            var user = await _dbContext.Users.WherePersonId(Convert.ToInt32(personId))
                                             .IncludePerson()
                                             .IncludeRoles()
                                             .IncludeAddress()
                                             .SingleOrDefaultAsync();
            return user;
        }

    }
}