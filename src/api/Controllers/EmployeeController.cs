using api.Models.ResultModel.Successes;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/v1/employee")]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
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