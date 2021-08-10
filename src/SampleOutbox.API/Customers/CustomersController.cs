using System;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleOutbox.Application.Configuration;
using SampleOutbox.Application.Customers;
using SampleOutbox.Application.Customers.GetCustomerDetails;
using SampleOutbox.Application.Customers.RegisterCustomer;

namespace SampleOutbox.API.Customers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("{customerId}")]
        [HttpGet]
        [ProducesResponseType(typeof(CustomerDetailsDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCustomerDetails(Guid customerId)
        {
            var customer = await _mediator.Send(new GetCustomerDetailsQuery(customerId));
            return Ok(customer);
        }

        /// <summary>
        /// Register customer.
        /// </summary>
        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerRequest request)
        {
            var customer = await _mediator.Send(new RegisterCustomerCommand(request.Email,request.Name));
            return Created(string.Empty,customer);
        }
    }
}