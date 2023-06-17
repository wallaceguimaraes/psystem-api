using api.Models.EntityModel.Companies;
using api.ResultModel.Successes.Companies;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel.Successes.Companies
{
    public class CompanyListJson : IActionResult
    {
        public CompanyListJson() { }

        public CompanyListJson(ICollection<Company> companies, long count)
        {
            Companies = companies.Select(company => new CompanyJson(company)).ToList();
            Count = count;
        }

        public ICollection<CompanyJson> Companies { get; set; }
        public long Count { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}