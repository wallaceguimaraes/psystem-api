using api.Data.Context;
using api.Models.EntityModel.Persons;
using api.Models.EntityModel.Roles;

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

        public Role Role { get; private set; }
        public Person Person { get; private set; }

        public bool EmployeeRegisterError { get; private set; }
        public bool RoleRegisterError { get; private set; }





        public async Task<bool> CreateRole(Role role)
        {
            try
            {
                _dbContext.Roles.Add(role);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var error = ex;
                return !(RoleRegisterError = true);
            }

            Role = role;
            return true;
        }

        public async Task<bool> CreateEmployee(Person person)
        {
            //pesquisa role
            //salva roleuser com Id de role e user
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