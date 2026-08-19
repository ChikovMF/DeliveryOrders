using Microsoft.EntityFrameworkCore;
using Store.Records;

namespace Store;

/// <summary>
/// Контекст базы данных.
/// </summary>
public interface IAppDbContext
{
    /// <summary>
    /// Заказы.
    /// </summary>
    DbSet<OrderRecord> Orders { get; init; }

    /// <summary>
    /// Сохранение изменений в базе данных.
    /// </summary>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}