using System.Threading;
using System.Threading.Tasks;
using SampleOutbox.Domain.SeedWork;
using SampleOutbox.Infrastructure.Database;

namespace SampleOutbox.Infrastructure.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrdersContext _ordersContext;

        public UnitOfWork(OrdersContext ordersContext)
        {
            _ordersContext = ordersContext;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _ordersContext.SaveChangesAsync(cancellationToken);
        }
    }
}