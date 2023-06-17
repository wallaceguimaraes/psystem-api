using api.Models.ResultModel.Errors;
using api.Models.ResultModel.Successes.Roles;
using api.Models.ServiceModel.Employees;
using api.Models.ViewModel.Roles;
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

        [HttpPost, Route("role")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleModel model)
        {
            if (!await _service.CreateRole(model.Map()))
            {
                return new EmployeeErrorResult(_service);
            }

            return new RoleJson(_service.Role);
        }
    }
}