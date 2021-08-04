using System.Reflection;
using SampleOutbox.Application.Customers.RegisterCustomer;

namespace SampleOutbox.Infrastructure.Processing
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(RegisterCustomerCommand).Assembly;
    }
}