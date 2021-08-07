using Autofac;
using SampleOutbox.Application.Customers.DomainServices;
using SampleOutbox.Domain.Customers;

namespace SampleOutbox.Infrastructure.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerUniquenessChecker>()
                .As<ICustomerUniquenessChecker>();
        }
    }
}