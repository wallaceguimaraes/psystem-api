using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel.Successes
{
    public class CrawllerSuccessResult : IActionResult
    {
        public CrawllerSuccessResult() { }

        public CrawllerSuccessResult(string number, string error)
        {
            Benefit = number ?? "";
            Message = error ?? "success";
        }

        public string? Benefit { get; set; }
        public string? Message { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new ObjectResult(this).ExecuteResultAsync(context);
        }
    }
}