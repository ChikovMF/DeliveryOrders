namespace Domain.Orders;

/// <summary>
/// Репозиторий заказов.
/// </summary>
public interface IOrderRepository
{
    /// <summary>
    /// Получить заказ по номеру.
    /// </summary>
    /// <returns>Заказ или null, если не найден</returns>
    Task<Order?> GetAsync(OrderNumber orderNumber, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получить список заказов с пагинацией.
    /// </summary>
    Task<IReadOnlyList<Order>> GetAllAsync(int offset, int limit, CancellationToken cancellationToken);
    
    /// <summary>
    /// Добавить заказ.
    /// </summary>
    Task AddAsync(Order order, CancellationToken cancellationToken);
}