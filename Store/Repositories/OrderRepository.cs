using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Store.Mappers;

namespace Store.Repositories;

internal sealed class OrderRepository : IOrderRepository
{
    private readonly IAppDbContext _dbContext;

    public OrderRepository(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Order?> GetAsync(OrderNumber orderNumber, CancellationToken cancellationToken)
    {
        var record = await _dbContext.Orders
            .SingleOrDefaultAsync(order => order.Number == orderNumber.ToString(), cancellationToken);

        return record?.ToDomain();
    }

    public async Task<IReadOnlyList<Order>> GetAllAsync(int offset, int limit, CancellationToken cancellationToken)
    {
        var orders = await _dbContext.Orders
            .OrderBy(order => order.Number)
            .Skip(offset)
            .Take(limit)
            .ToListAsync(cancellationToken);

        return orders.Select(order => order.ToDomain()).ToList();
    }

    public Task AddAsync(Order order, CancellationToken cancellationToken)
    {
        var record = order.ToRecord();
        _dbContext.Orders.Add(record);
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}