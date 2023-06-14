using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Results.Errors
{
    public class ErrorJson : IActionResult
    {
        public ErrorJson(){}
        public ErrorJson(int code, string description)
        {
            Code = code;
            Description = description;
        }
        public int Code { get; set; }
        public string Description { get; set; }
        
        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}