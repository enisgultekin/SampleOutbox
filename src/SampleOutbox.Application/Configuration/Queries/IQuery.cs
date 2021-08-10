using MediatR;

namespace SampleOutbox.Application.Configuration.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
        
    }
}