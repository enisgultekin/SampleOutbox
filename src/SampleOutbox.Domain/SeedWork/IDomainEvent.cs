using System;
using MediatR;

namespace SampleOutbox.Domain.SeedWork
{
    public interface IDomainEvent : INotification
    {
        DateTime OccuredOn { get; }
    }
}