using api.Models.ResultModel.Errors.Company;
using api.Models.ResultModel.Successes.Companies;
using api.Models.ServiceModel.Companies;
using api.Models.ViewModel.Companies;
using api.ResultModel.Successes.Companies;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/v1/company")]
    public class CompanyController : Controller
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly CompanyService _service;

        public CompanyController(ILogger<CompanyController> logger, CompanyService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyModel model)
        {
            if (!await _service.CreateCompany(model.Map()))
                return new CompanyErrorResult(_service);

            return new CompanyJson(_service.Company);
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies([FromQuery] GetCompanyModel model)
        {
            var (companies, count) = await _service.GetCompanies(model);

            if (!companies.Any() && _service.CompanyListError)
                return new CompanyErrorResult(_service);

            return new CompanyListJson(companies, count);
        }

        [HttpPut, Route("{companyId}")]
        public async Task<IActionResult> UpdateCompany([FromRoute] string companyId, [FromBody] CreateCompanyModel model)
        {
            if (!await _service.UpdateCompany(model.Map(), Convert.ToInt32(companyId)))
            {
                return new CompanyErrorResult(_service);
            }

            return new CompanyJson(_service.Company);
        }
    }
}