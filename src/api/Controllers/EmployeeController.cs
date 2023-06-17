using api.Models.ResultModel.Errors;
using api.Models.ResultModel.Successes.Employees;
using api.Models.ServiceModel.Employees;
using api.Models.ViewModel.Persons;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/v1/employee")]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly EmployeeService _service;

        public EmployeeController(ILogger<EmployeeController> logger, EmployeeService service)
        {
            _logger = logger;
            _service = service;
        }

        // [HttpPost, Route("role")]
        // public async Task<IActionResult> CreateRole([FromBody] CreateRoleModel model)
        // {
        //     if (!await _service.CreateRole(model.Map()))
        //     {
        //         return new EmployeeErrorResult(_service);
        //     }

        //     return new RoleJson(_service.Role);
        // }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> CreateEmployee([FromBody] CreatePersonModel model)
        {
            var body = Request.Body;
            var contentLength = Request.ContentLength;

            if (!await _service.CreateEmployee(model.Map()))
            {
                return new EmployeeErrorResult(_service);
            }

            return new EmployeeJson(_service.Person);
        }


    }
}