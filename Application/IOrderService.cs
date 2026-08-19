using Domain.Orders;

namespace Application;

/// <summary>
/// Сервис работы с заказами.
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// Получить заказ по номеру.
    /// </summary>
    /// <returns>Заказ или null, если не найден</returns>
    Task<Order?> GetAsync(OrderNumber orderNumber, CancellationToken cancellationToken);

    /// <summary>
    /// Получить список заказов с пагинацией.
    /// </summary>
    /// <param name="offset">Количество пропускаемых заказов</param>
    /// <param name="limit">Максимальное количество возвращаемых заказов</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task<IReadOnlyList<Order>> GetAllAsync(int offset, int limit, CancellationToken cancellationToken);
}