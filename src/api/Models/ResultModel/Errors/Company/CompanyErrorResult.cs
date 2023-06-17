using api.Models.ServiceModel.Companies;
using api.Results.Errors;

namespace api.Models.ResultModel.Errors.Company
{
    public class CompanyErrorResult : UnprocessableEntityJson
    {
        public CompanyErrorResult() { }

        public CompanyErrorResult(CompanyService service)
        {
            if (service.CompanyRegisterError)
                Error = "COMPANY_REGISTER_ERROR";
            if (service.CompanyNotFound)
                Error = "COMPANY_NOT_FOUND";
            if (service.CompanyListError)
                Error = "COMPANY_LIST_ERROR";

        }
    }
}