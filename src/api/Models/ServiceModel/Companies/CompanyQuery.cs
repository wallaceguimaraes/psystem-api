using api.Models.EntityModel.Companies;

namespace api.Models.ServiceModel.Companies
{
    public static class CompanyQuery
    {
        public static IQueryable<Company> WhereId(this IQueryable<Company> companies, long id)
        {
            return companies.Where(company => company.Id == id);
        }


    }
}