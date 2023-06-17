using api.Data.Context;
using api.Models.EntityModel.Companies;
using api.Models.ViewModel.Companies;
using Microsoft.EntityFrameworkCore;

namespace api.Models.ServiceModel.Companies
{
    public class CompanyService
    {
        private readonly ApiDbContext? _dbContext;
        private readonly ILogger<CompanyService>? _logger;
        public CompanyService(ApiDbContext dbContext, ILogger<CompanyService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Company Company { get; private set; }

        public List<Company> Companies { get; private set; }

        public bool CompanyRegisterError { get; private set; }
        public bool CompanyListError { get; private set; }

        public bool CompanyNotFound { get; private set; }

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

        public async Task<(List<Company> companies, long count)> GetCompanies(GetCompanyModel model)
        {
            try
            {
                var query = _dbContext.Companies;
                var count = await query.CountAsync();

                return (await query.ToListAsync(), count);

            }
            catch (Exception ex)
            {
                var error = ex;
                CompanyListError = true;
            }

            return (new List<Company>(), 0);
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