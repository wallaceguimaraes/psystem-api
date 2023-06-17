using api.Models.EntityModel.Companies;
using Microsoft.AspNetCore.Mvc;

namespace api.ResultModel.Successes.Companies
{
    public class CompanyJson : IActionResult
    {
        public CompanyJson() { }

        public CompanyJson(Company company)
        {
            Id = company.Id.ToString();
            FullName = company.FullName;
            TradeName = company.TradeName;
            TaxDocument = company.TaxDocument;
            CreatedAt = company.SystemImplementation;

        }

        public string Id { get; set; }
        public string FullName { get; set; }
        public string TradeName { get; set; }
        public string TaxDocument { get; set; }
        public DateTime CreatedAt { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}