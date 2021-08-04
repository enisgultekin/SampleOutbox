using System.Threading;
using System.Threading.Tasks;
using SampleOutbox.Application.Configuration;
using SampleOutbox.Application.Configuration.Commands;

namespace SampleOutbox.Application.Customers.RegisterCustomer
{
    public class RegisterCustomerCommandHandler : ICommandHandler<RegisterCustomerCommand, CustomerDto>
    {
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public RegisterCustomerCommandHandler(IExecutionContextAccessor executionContextAccessor)
        {
            _executionContextAccessor = executionContextAccessor;
        }
        public async Task<CustomerDto> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {
            System.Diagnostics.Debug.WriteLine(_executionContextAccessor.CorrelationId);
            return new CustomerDto();
        }
    }
}