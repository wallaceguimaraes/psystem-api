using api.Models.EntityModel.Persons;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel.Successes.Employees
{
    public class EmployeeJson : IActionResult
    {
        public EmployeeJson() { }

        public EmployeeJson(Person person)
        {
            Id = person.Id.ToString();
            FullName = person.NaturalPerson.FullName;
            Email = person.User.Email;
            TaxDocument = person.JuristicPerson != null ? person.JuristicPerson.TaxDocument : person.NaturalPerson.TaxDocument;
            Role = person.RoleUser.Role.Name;
            CreatedAt = person.CreatedAt;
        }

        public string Id { get; set; }
        public string FullName { get; set; }
        public string TaxDocument { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}