using Domain.Orders;

namespace Application;

public sealed class OrderService : IOrderService
{
    public Task<Order?> GetAsync(OrderNumber orderNumber, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Order>> GetAllAsync(int offset, int limit, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}