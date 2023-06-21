using api.Data.Context;
using api.Models.EntityModel.Persons;
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

        public async Task<bool> CreateEmployee(Person person, long companyId)
        {
            bool roleExists = await _dbContext.Roles.WhereCompanyId(companyId)
                                                    .WhereId(person.User.Role.Id)
                                                    .AnyAsync();
            if (!roleExists)
                return !(EmployeeRegisterError = true);

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

            return true;
        }

    }
}