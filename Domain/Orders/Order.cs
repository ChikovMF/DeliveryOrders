namespace Domain.Orders;

/// <summary>
/// Заказ.
/// </summary>
public sealed class Order
{
    private Order(OrderNumber number, 
        string senderCity, 
        string senderAddress, 
        string recipientCity,
        string recipientAddress, 
        decimal weight, 
        DateTimeOffset pickupDate)
    {
        Number = number;
        SenderCity = senderCity;
        SenderAddress = senderAddress;
        RecipientCity = recipientCity;
        RecipientAddress = recipientAddress;
        Weight = weight;
        PickupDate = pickupDate;
    }

    /// <summary>
    /// Номер.
    /// </summary>
    public OrderNumber Number { get; }

    /// <summary>
    /// Город отправителя.
    /// </summary>
    public string SenderCity { get; }

    /// <summary>
    /// Адрес отправителя.
    /// </summary>
    public string SenderAddress { get; }

    /// <summary>
    /// Город получателя.
    /// </summary>
    public string RecipientCity { get; }

    /// <summary>
    /// Адрес получателя.
    /// </summary>
    public string RecipientAddress { get; }

    /// <summary>
    /// Вес.
    /// </summary>
    public decimal Weight { get; }

    /// <summary>
    /// Дата и время забора.
    /// </summary>
    public DateTimeOffset PickupDate { get; }
}