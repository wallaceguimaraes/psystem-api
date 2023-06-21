using api.Models.ServiceModel.Employees;
using api.Results.Errors;
// using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel.Errors
{
    public class EmployeeErrorResult : UnprocessableEntityJson
    {
        public EmployeeErrorResult() { }

        public EmployeeErrorResult(EmployeeService service)
        {
            if (service.EmployeeRegisterError)
                Error = "EMPLOYEE_REGISTER_ERROR";

        }
    }
}