using api.Data.Context;
using api.Models.EntityModel.Roles;
using api.Models.ServiceModel.Companies;
using Microsoft.EntityFrameworkCore;

namespace api.Models.ServiceModel.Roles
{
    public class RoleService
    {
        private readonly ApiDbContext? _dbContext;
        private readonly ILogger<RoleService>? _logger;

        public RoleService(ApiDbContext dbContext, ILogger<RoleService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Role Role { get; private set; }
        public bool RoleRegisterError { get; private set; }
        public bool CompanyNotFound { get; private set; }
        public bool RoleAlreadyExists { get; private set; }



        public async Task<bool> CreateRole(Role? role)
        {
            bool companyExists = await _dbContext.Companies.WhereId((long)role.CompanyId)
                                                           .AnyAsync();
            if (!companyExists)
                return !(CompanyNotFound = true);

            bool roleExists = await _dbContext.Roles.WhereCompanyId((long)role.CompanyId)
                                                    .WhereName(role.Name)
                                                    .AnyAsync();
            if (roleExists)
                return !(RoleAlreadyExists = true);

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
    }
}