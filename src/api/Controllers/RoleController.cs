using api.Data.Context;
using api.Models.ResultModel.Errors;
using api.Models.ResultModel.Successes.Roles;
using api.Models.ServiceModel.Roles;
using api.Models.ViewModel.Roles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/v1/role")]
    public class RoleController : Controller
    {
        private readonly ILogger<RoleController> _logger;

        private readonly RoleService _service;

        private readonly ApiDbContext _dbContext;

        public RoleController(ILogger<RoleController> logger, ApiDbContext dbContext, RoleService service)
        {
            _logger = logger;
            _dbContext = dbContext;
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetRoles([FromQuery] string companyId)
        {
            var roles = await _dbContext.Roles.Where(role => role.CompanyId == Convert.ToInt32(companyId)).ToListAsync();
            return new RoleListJson(roles, roles.Count);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleModel model)
        {
            if (!await _service.CreateRole(model.Map()))
                return new RoleErrorResult(_service);

            return new RoleJson(_service.Role);
        }
    }



}