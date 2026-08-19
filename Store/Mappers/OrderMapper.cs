using Domain.Orders;
using Store.Records;

namespace Store.Mappers;

public static class OrderMapper
{
    public static OrderRecord ToRecord(this Order order)
    {
        return new OrderRecord
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

    public static Order ToDomain(this OrderRecord record)
    {
        var orderNumber = OrderNumber.Parse(record.Number);

        if (!Order.TryCreate(
                OrderNumber.Parse(record.Number),
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