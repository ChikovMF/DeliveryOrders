using Domain.Orders;

namespace Application.Orders;

internal sealed class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task<Order?> GetAsync(OrderNumber orderNumber, CancellationToken cancellationToken) =>
        _orderRepository.GetAsync(orderNumber, cancellationToken);

    public Task<IReadOnlyList<Order>> GetAllAsync(int offset, int limit, CancellationToken cancellationToken) =>
        _orderRepository.GetAllAsync(offset, limit, cancellationToken);

    public Task CreateAsync(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        if (!Order.TryCreate(
            command.SenderCity,
            command.SenderAddress,
            command.RecipientCity,
            command.RecipientAddress,
            command.Weight,
            command.PickupDate,
            out var order,
            out var error))
        {
            throw new InvalidOperationException("Ошибка создания заказа: " + error);
        }

        return _orderRepository.AddAsync(order, cancellationToken);
    }
}