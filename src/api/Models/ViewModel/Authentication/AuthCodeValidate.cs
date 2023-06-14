using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace api.Models.ViewModel.v2.Authentication
{
    public class AuthCodeValidate
    {

        [Display(Name = "code"), JsonRequired]
        public int Code { get; set; }
    }
}
