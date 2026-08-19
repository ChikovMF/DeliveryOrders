namespace Store;

public interface IDatabaseMigrator
{
    /// <summary>
    /// Применяет все миграции к базе данных.
    /// </summary>
    Task MigrateAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Проверяет, есть ли неприменённые миграции.
    /// </summary>
    Task<bool> HasPendingMigrationsAsync(CancellationToken cancellationToken);
}