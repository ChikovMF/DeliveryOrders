using Store;

namespace Web.Host;

/// <summary>
/// Сервис для применения миграций базы данных при запуске приложения.
/// </summary>
public class DatabaseMigrationHostedService(
    IDatabaseMigrator migrator,
    ILogger<DatabaseMigrationHostedService> logger)
    : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        if (!await migrator.HasPendingMigrationsAsync(cancellationToken))
        {
            logger.LogInformation("Отсутствуют ожидающие миграции базы данных. Применение миграций не требуется.");
            return;
        }

        try
        {
            await migrator.MigrateAsync(cancellationToken);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Ошибка при применении миграций базы данных.");
            throw;
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}