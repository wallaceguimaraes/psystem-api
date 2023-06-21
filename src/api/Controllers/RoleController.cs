using api.Data.Context;
using api.Extensions.Http;
using api.Filters;
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


        [HttpGet, Auth]
        public async Task<IActionResult> GetRoles()
        {

            var whoAmI = HttpContext.WhoAmI();
            var companyId = whoAmI.Person.CompanyId;

            var roles = await _dbContext.Roles.Where(role => role.CompanyId == companyId).ToListAsync();
            return new RoleListJson(roles, roles.Count);
        }

        [HttpPost, Auth]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleModel model)
        {
            // var user = User.Claims;

            // var personIdClaim = User.FindFirst(ApiClaimTypes.PersonId);
            // var saltClaim = User.FindFirst(ApiClaimTypes.Salt);

            if (!await _service.CreateRole(model.Map()))
                return new RoleErrorResult(_service);

            return new RoleJson(_service.Role);
        }
    }



}