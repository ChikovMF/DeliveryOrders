using Domain.Orders;
using Web.Contracts.Orders;

namespace Web.Host.Mappers;

internal static class OrderMapper
{
    public static OrderModelResponse ToResponse(this Order order)
    {
        return new OrderModelResponse(
            order.Number.ToString(),
            order.SenderCity,
            order.SenderAddress,
            order.RecipientCity,
            order.RecipientAddress,
            order.Weight,
            order.PickupDate);
    }

    public static OrderListModelResponse ToResponse(this IReadOnlyCollection<Order> orders, int limit, int offset)
    {
        var items = orders.Select(o => new OrderListModelResponse.OrderListModelItem(
            o.Number.ToString(),
            o.SenderCity,
            o.SenderAddress,
            o.RecipientCity,
            o.RecipientAddress,
            o.Weight,
            o.PickupDate)).ToList();

        return new OrderListModelResponse(items, limit, offset);
    }
}