using System.ComponentModel.DataAnnotations;

namespace api.Models.ViewModel.Employee
{
    public class CreateEmployeeModel
    {
        [Display(Name = "role")]
        public long Role { get; set; }

        [Display(Name = "fullName")]
        public string? FullName { get; set; }
        public bool IsPatient { get; set; }
        public bool IsEmployee { get; set; }

    }
}