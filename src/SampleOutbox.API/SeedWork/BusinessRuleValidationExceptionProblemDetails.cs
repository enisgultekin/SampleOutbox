using Microsoft.AspNetCore.Http;
using SampleOutbox.Domain.SeedWork;

namespace SampleOutbox.API.SeedWork
{
    public class BusinessRuleValidationExceptionProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public BusinessRuleValidationExceptionProblemDetails(BusinessRuleValidationException ex)
        {
            this.Title = "Business rule validation error";
            this.Status = StatusCodes.Status409Conflict;
            this.Detail = ex.Details;
            this.Type = "https://somedomain/business-rule-validation-error";
        }
    }
}