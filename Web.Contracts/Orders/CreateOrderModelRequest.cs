namespace Web.Contracts.Orders;

/// <summary>
/// Запрос на создание заказа.
/// </summary>
public sealed class CreateOrderModelRequest(
    string senderCity,
    string senderAddress,
    string recipientCity,
    string recipientAddress,
    decimal weight,
    DateTimeOffset pickupDate)
{
    /// <summary>
    /// Город отправителя.
    /// </summary>
    public string? SenderCity { get; } = senderCity;

    /// <summary>
    /// Адрес отправителя.
    /// </summary>
    public string? SenderAddress { get; } = senderAddress;

    /// <summary>
    /// Город получателя.
    /// </summary>
    public string? RecipientCity { get; } = recipientCity;

    /// <summary>
    /// Адрес получателя.
    /// </summary>
    public string? RecipientAddress { get; } = recipientAddress;

    /// <summary>
    /// Вес.
    /// </summary>
    public decimal? Weight { get; } = weight;

    /// <summary>
    /// Дата и время забора.
    /// </summary>
    public DateTimeOffset? PickupDate { get; } = pickupDate;
}