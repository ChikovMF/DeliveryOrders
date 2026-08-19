using Domain;

namespace Application;

public sealed class OrderService : IOrderService
{
    public Order? GetAsync(OrderNumber orderNumber, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<Order> GetAllAsync(int offset, int limit, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}