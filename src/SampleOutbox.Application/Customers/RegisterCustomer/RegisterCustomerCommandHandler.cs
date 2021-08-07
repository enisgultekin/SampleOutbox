using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SampleOutbox.Application.Configuration.Commands;
using SampleOutbox.Domain.Customers;
using SampleOutbox.Domain.SeedWork;

namespace SampleOutbox.Application.Customers.RegisterCustomer
{
    public class RegisterCustomerCommandHandler : ICommandHandler<RegisterCustomerCommand, CustomerDto>
    {
        private readonly ICustomerUniquenessChecker _customerUniquenessChecker;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterCustomerCommandHandler(ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork,
         ICustomerUniquenessChecker customerUniquenessChecker)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _customerUniquenessChecker = customerUniquenessChecker;
        }
        public async Task<CustomerDto> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = Customer.CreateRegistered(request.Email, request.Name, _customerUniquenessChecker);
            await _customerRepository.AddAsync(customer);
            await _unitOfWork.CommitAsync(cancellationToken);
            
            return new CustomerDto();
        }
    }
}