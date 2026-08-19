using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Store.Converters;
using Store.Records;

namespace Store;

internal class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IAppDbContext
{
    public DbSet<OrderRecord> Orders { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<DateTimeOffset>()
            .HaveConversion<DateTimeOffsetConverter>();

        configurationBuilder
            .Properties<DateTimeOffset?>()
            .HaveConversion<NullableDateTimeOffsetConverter>();
        
        base.ConfigureConventions(configurationBuilder);
    }
}