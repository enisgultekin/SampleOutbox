using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleOutbox.Application.Configuration;
using SampleOutbox.Application.Customers;
using SampleOutbox.Application.Customers.RegisterCustomer;

namespace SampleOutbox.API.Customers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public CustomersController(IMediator mediator, IExecutionContextAccessor executionContextAccessor)
        {
            _mediator = mediator;
            _executionContextAccessor = executionContextAccessor;
        }

        /// <summary>
        /// Register customer.
        /// </summary>
        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerRequest request)
        {
            await _mediator.Send(new RegisterCustomerCommand(request.Email,request.Name));
            return Ok();
        }
    }
}