namespace Web.Contracts.Orders;

/// <summary>
/// Модель ответа для заказа.
/// </summary>
public sealed class OrderModelResponse
{
    public OrderModelResponse(
        string number,
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
    public string Number { get; init; }

    /// <summary>
    /// Город отправителя.
    /// </summary>
    public string SenderCity { get; init; }

    /// <summary>
    /// Адрес отправителя.
    /// </summary>
    public string SenderAddress { get; init; }

    /// <summary>
    /// Город получателя.
    /// </summary>
    public string RecipientCity { get; init; }

    /// <summary>
    /// Адрес получателя.
    /// </summary>
    public string RecipientAddress { get; init; }

    /// <summary>
    /// Вес.
    /// </summary>
    public decimal Weight { get; init; }

    /// <summary>
    /// Дата и время забора.
    /// </summary>
    public DateTimeOffset PickupDate { get; init; }
}