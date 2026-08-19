using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Store.Records;

namespace Store;

internal class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<OrderRecord> Orders { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}