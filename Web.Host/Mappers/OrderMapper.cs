using Application.Orders;
using Domain.Orders;
using Web.Contracts.Orders;

namespace Web.Host.Mappers;

public static class OrderMapper
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

    public static OrderListModelResponse ToResponse(this IReadOnlyCollection<Order> orders)
    {
        // ToDo!
        return null;
    }
}