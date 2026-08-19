namespace Web.Contracts.Orders;

public sealed class OrderListModelResponse(
    IReadOnlyList<OrderListModelResponse.OrderListModelItem> orders,
    int limit,
    int offset)
{
    public IReadOnlyList<OrderListModelItem> Orders { get; } = orders;

    public int Offset { get; } = offset;

    public int Limit { get; } = limit;

    public sealed class OrderListModelItem(
        string number,
        string senderCity,
        string senderAddress,
        string recipientCity,
        string recipientAddress,
        decimal weight,
        DateTimeOffset pickupDate)
    {
        /// <summary>
        /// Номер.
        /// </summary>
        public string Number { get; } = number;

        /// <summary>
        /// Город отправителя.
        /// </summary>
        public string SenderCity { get; } = senderCity;

        /// <summary>
        /// Адрес отправителя.
        /// </summary>
        public string SenderAddress { get; } = senderAddress;

        /// <summary>
        /// Город получателя.
        /// </summary>
        public string RecipientCity { get; } = recipientCity;

        /// <summary>
        /// Адрес получателя.
        /// </summary>
        public string RecipientAddress { get; } = recipientAddress;

        /// <summary>
        /// Вес.
        /// </summary>
        public decimal Weight { get; } = weight;

        /// <summary>
        /// Дата и время забора.
        /// </summary>
        public DateTimeOffset PickupDate { get; } = pickupDate;
    }
}