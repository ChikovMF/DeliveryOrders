using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Store;

internal sealed class DatabaseMigrator(IServiceScopeFactory scopeFactory) : IDatabaseMigrator
{
    public async Task MigrateAsync(CancellationToken cancellationToken)
    {
        using var scope = scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await dbContext.Database.MigrateAsync(cancellationToken);
    }

    public async Task<bool> HasPendingMigrationsAsync(CancellationToken cancellationToken)
    {
        using var scope = scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        var pending = await dbContext.Database.GetPendingMigrationsAsync(cancellationToken);
        return pending.Any();
    }
}