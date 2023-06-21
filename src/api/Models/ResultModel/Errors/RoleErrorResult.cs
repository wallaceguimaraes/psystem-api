using api.Models.ServiceModel.Roles;
using api.Results.Errors;

namespace api.Models.ResultModel.Errors
{
    public class RoleErrorResult : UnprocessableEntityJson
    {
        public RoleErrorResult() { }

        public RoleErrorResult(RoleService service)
        {
            if (service.RoleRegisterError)
                Error = "ROLE_REGISTER_ERROR";
            if (service.CompanyNotFound)
                Error = "COMPANY_NOT_FOUND";
            if (service.RoleAlreadyExists)
                Error = "ROLE_ALREADY_EXISTS";
        }
    }
}