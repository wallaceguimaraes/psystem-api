using Microsoft.AspNetCore.Mvc;

namespace api.ResultModel.Successes.Authentication
{
    public class TokenJson : IActionResult
    {
        public TokenJson() { }

        public TokenJson(string token, DateTime date)
        {
            Token = token;
            ExpiresIn = (int)Math.Round((date - DateTime.UtcNow).TotalMinutes);
        }

        public string Token { get; set; }
        public int ExpiresIn { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}