using api.Data.Context;
using api.Models.ResultModel.Successes.Roles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/v1/role")]
    public class RoleController : Controller
    {
        private readonly ILogger<RoleController> _logger;
        private readonly ApiDbContext _dbContext;

        public RoleController(ILogger<RoleController> logger, ApiDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetRoles([FromQuery] string companyId)
        {
            var roles = await _dbContext.Roles.Where(role => role.Id == Convert.ToInt32(companyId)).ToListAsync();
            return new RoleListJson(roles, roles.Count);
        }
    }



}