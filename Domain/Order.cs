namespace Domain;

/// <summary>
/// Заказ.
/// </summary>
public sealed class Order
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Город отправителя.
    /// </summary>
    public string SenderCity { get; set; }

    /// <summary>
    /// Адрес отправителя.
    /// </summary>
    public string SenderAddress { get; set; }

    /// <summary>
    /// Город получателя.
    /// </summary>
    public string RecipientCity { get; set; }

    /// <summary>
    /// Адрес получателя.
    /// </summary>
    public string RecipientAddress { get; set; }

    /// <summary>
    /// Вес.
    /// </summary>
    public decimal Weight { get; set; }

    /// <summary>
    /// Дата и время забора.
    /// </summary>
    public DateTimeOffset PickupDate { get; set; }
}