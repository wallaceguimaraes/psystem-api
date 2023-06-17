using api.Models.ServiceModel.Employees;
using api.Results.Errors;
// using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel.Errors
{
    public class EmployeeErrorResult : UnprocessableEntityJson
    {
        public EmployeeErrorResult() { }

        public EmployeeErrorResult(Employee service)
        {
            if (service.CompanyRegisterError)
                Error = "COMPANY_REGISTER_ERROR";
            if (service.EmployeeRegisterError)
                Error = "EMPLOYEE_REGISTER_ERROR";
            if (service.CompanyNotFound)
                Error = "COMPANY_NOT_FOUND";
        }
    }
}