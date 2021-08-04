using System;
using SampleOutbox.Domain.SeedWork;

namespace SampleOutbox.Domain.Customers
{
    public class CustomerId : TypedIdValueBase
    {
        public CustomerId(Guid value) : base(value)
        {
        }
    }
}