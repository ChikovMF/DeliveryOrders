using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

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

    public static bool TryCreate(
        string senderCity,
        string senderAddress,
        string recipientCity,
        string recipientAddress,
        decimal weight,
        DateTimeOffset pickupDate,
        [NotNullWhen(true)] out Order? order,
        [NotNullWhen(false)] out string? error)
    {
        order = null;
        error = null;

        if (string.IsNullOrWhiteSpace(senderCity))
        {
            error = "Город отправителя обязателен";
            return false;
        }

        if (string.IsNullOrWhiteSpace(senderAddress))
        {
            error = "Адрес отправителя обязателен";
            return false;
        }

        if (string.IsNullOrWhiteSpace(recipientCity))
        {
            error = "Город получателя обязателен";
            return false;
        }

        if (string.IsNullOrWhiteSpace(recipientAddress))
        {
            error = "Адрес получателя обязателен";
            return false;
        }

        if (weight <= 0)
        {
            error = "Вес груза должен быть больше нуля";
            return false;
        }

        if (pickupDate < DateTimeOffset.UtcNow)
        {
            error = "Дата забора не может быть в прошлом";
            return false;
        }

        order = new Order(
            OrderNumber.New(),
            senderCity,
            senderAddress,
            recipientCity,
            recipientAddress,
            weight,
            pickupDate);

        return true;
    }
}