using Domain.Orders;
using Web.Contracts.Orders;

namespace Web.Host.Mappers;

internal static class OrderMapper
{
    public static OrderModelResponse ToResponse(this Order order)
    {
        return new OrderModelResponse
        {
            Number = order.Number.ToString(),
            SenderCity = order.SenderCity,
            SenderAddress = order.SenderAddress,
            RecipientCity = order.RecipientCity,
            RecipientAddress = order.RecipientAddress,
            Weight = order.Weight,
            PickupDate = order.PickupDate
        };
    }

    public static OrderListModelResponse ToResponse(this IReadOnlyCollection<Order> orders, int limit, int offset)
    {
        var items = orders.Select(o => new OrderListModelResponse.OrderListModelItem
        {
            Number = o.Number.ToString(),
            SenderCity = o.SenderCity,
            SenderAddress = o.SenderAddress,
            RecipientCity = o.RecipientCity,
            RecipientAddress = o.RecipientAddress,
            Weight = o.Weight,
            PickupDate = o.PickupDate
        }).ToList();

        return new OrderListModelResponse
        {
            Limit = limit,
            Offset = offset,
            Orders = items,
        };
    }
}