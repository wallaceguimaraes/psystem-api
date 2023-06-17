using api.Data.Context;
using api.Models.EntityModel.Companies;
using api.Models.ServiceModel.Companies;
using Microsoft.EntityFrameworkCore;

namespace api.Models.ServiceModel.Employees
{
    public class Employee
    {
        private readonly ApiDbContext? _dbContext;
        private readonly ILogger<Employee>? _logger;
        public Employee(ApiDbContext dbContext, ILogger<Employee> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Company Company { get; private set; }
        public bool CompanyRegisterError { get; private set; }
        public bool CompanyNotFound { get; private set; }
        public bool EmployeeRegisterError { get; private set; }

        public async Task<bool> CreateCompany(Company company)
        {
            try
            {
                _dbContext.Companies.Add(company);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var error = ex;
                return !(CompanyRegisterError = true);
            }

            Company = company;
            return true;
        }

        public async Task<bool> UpdateCompany(Company company, long companyId)
        {
            Company = await _dbContext.Companies.WhereId(companyId).SingleOrDefaultAsync();

            if (Company is null)
                return !(CompanyNotFound = true);

            Company.BusinessTypeAcronym = company.BusinessTypeAcronym;
            Company.BusinessTypeName = company.BusinessTypeName;
            Company.CnaeCode = company.CnaeCode;
            Company.FullName = company.FullName;
            Company.TradeName = company.TradeName;
            Company.TaxDocument = company.TaxDocument;

            try
            {
                _dbContext.Companies.Update(Company);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var error = ex;
                return !(CompanyRegisterError = true);
            }

            return true;
        }

    }
}