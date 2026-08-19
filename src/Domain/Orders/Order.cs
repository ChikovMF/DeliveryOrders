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
        OrderNumber orderNumber,
        string senderCity,
        string senderAddress,
        string recipientCity,
        string recipientAddress,
        decimal weight,
        DateTimeOffset pickupDate,
        [NotNullWhen(true)] out Order? order,
        [NotNullWhen(false)] out IReadOnlyList<string>? errors)
    {
        order = null;
        errors = null;

        var errorList = new List<string>();

        if (string.IsNullOrWhiteSpace(senderCity))
        {
            errorList.Add("город отправителя обязателен");
        }

        if (string.IsNullOrWhiteSpace(senderAddress))
        {
            errorList.Add("адрес отправителя обязателен");
        }

        if (string.IsNullOrWhiteSpace(recipientCity))
        {
            errorList.Add("город получателя обязателен");
        }

        if (string.IsNullOrWhiteSpace(recipientAddress))
        {
            errorList.Add("адрес получателя обязателен");
        }

        if (weight <= 0)
        {
            errorList.Add("вес груза должен быть больше нуля");
        }

        if (errorList.Any())
        {
            errors = errorList;
            return false;
        }

        order = new Order(
            orderNumber,
            senderCity,
            senderAddress,
            recipientCity,
            recipientAddress,
            weight,
            pickupDate);

        return true;
    }

    public static bool TryCreateNew(
        string senderCity,
        string senderAddress,
        string recipientCity,
        string recipientAddress,
        decimal weight,
        DateTimeOffset pickupDate,
        [NotNullWhen(true)] out Order? order,
        [NotNullWhen(false)] out IReadOnlyList<string>? errors)
    {
        order = null;
        errors = null;

        var ownErrors = new List<string>();

        if (pickupDate < DateTimeOffset.UtcNow)
        {
            ownErrors.Add("дата забора не может быть в прошлом");
        }

        var orderNumber = OrderNumber.New();
        var created = TryCreate(
            orderNumber,
            senderCity,
            senderAddress,
            recipientCity,
            recipientAddress,
            weight,
            pickupDate,
            out order,
            out var createErrors);

        if (ownErrors.Any() || createErrors?.Any() == true || !created || order is null)
        {
            order = null;
            errors = ownErrors.Concat(createErrors ?? Enumerable.Empty<string>()).ToList();
            return false;
        }

        return true;
    }
}