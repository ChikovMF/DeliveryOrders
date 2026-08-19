using Domain.Orders;
using Store.Records;

namespace Store.Mappers;

internal static class OrderMapper
{
    public static OrderRecord ToRecord(this Order order)
    {
        return new OrderRecord
        (
            order.Number.ToString(),
            order.SenderCity,
            order.SenderAddress,
            order.RecipientCity,
            order.RecipientAddress,
            order.Weight,
            order.PickupDate
        );
    }

    public static Order ToDomain(this OrderRecord record)
    {
        var orderNumber = OrderNumber.Parse(record.Number);

        if (!Order.TryCreate(
                orderNumber,
                record.SenderCity,
                record.SenderAddress,
                record.RecipientCity,
                record.RecipientAddress,
                record.Weight,
                record.PickupDate,
                out var order,
                out var errors))
        {
            throw new InvalidOperationException("Ошибка создания заказа: " + string.Join(", ", errors));
        }

        return order;
    }
}