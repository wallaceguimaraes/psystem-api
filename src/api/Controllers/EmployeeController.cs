using api.Models.ResultModel.Errors;
using api.Models.ResultModel.Successes;
using api.Models.ServiceModel.Employees;
using api.Models.ViewModel.Employee;
using api.ResultModel.Successes;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/v1/employee")]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly Employee _service;

        public EmployeeController(ILogger<EmployeeController> logger, Employee service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost, Route("signup/company")]
        public async Task<IActionResult> CreateCompany([FromBody] SignupCompanyViewModel model)
        {
            if (!await _service.CreateCompany(model.Map()))
            {
                return new EmployeeErrorResult(_service);
            }

            return new CompanyJson(_service.Company);
        }

        [HttpPut, Route("update/company/{companyId}")]
        public async Task<IActionResult> UpdateCompany([FromRoute] string companyId, [FromBody] SignupCompanyViewModel model)
        {
            if (!await _service.UpdateCompany(model.Map(), Convert.ToInt32(companyId)))
            {
                return new EmployeeErrorResult(_service);
            }

            return new CompanyJson(_service.Company);
        }

        [HttpGet, Route("list")]
        public Task<IActionResult> Index()
        {
            return Task.FromResult<IActionResult>(new CrawllerSuccessResult("12345", ""));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}