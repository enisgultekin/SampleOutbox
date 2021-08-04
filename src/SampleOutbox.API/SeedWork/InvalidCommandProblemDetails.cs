using Microsoft.AspNetCore.Http;
using SampleOutbox.Application.Configuration.Validation;

namespace SampleOutbox.API.SeedWork
{
    public class InvalidCommandProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public InvalidCommandProblemDetails(InvalidCommandException ex)
        {
            this.Title = ex.Message;
            this.Status = StatusCodes.Status400BadRequest;
            this.Detail = ex.Details;
            this.Type = "https://somedomain/validation-error";
        }
    }
}