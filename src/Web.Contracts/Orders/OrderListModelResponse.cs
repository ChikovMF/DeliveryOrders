namespace Web.Contracts.Orders;

public sealed class OrderListModelResponse
{
    public IReadOnlyList<OrderListModelItem> Orders { get; init; } = [];

    public int Offset { get; init; }

    public int Limit { get; init; }

    public sealed class OrderListModelItem
    {
        /// <summary>
        /// Номер.
        /// </summary>
        public string? Number { get; init; }

        /// <summary>
        /// Город отправителя.
        /// </summary>
        public string? SenderCity { get; init; }

        /// <summary>
        /// Адрес отправителя.
        /// </summary>
        public string? SenderAddress { get; init; }

        /// <summary>
        /// Город получателя.
        /// </summary>
        public string? RecipientCity { get; init; }

        /// <summary>
        /// Адрес получателя.
        /// </summary>
        public string? RecipientAddress { get; init; }

        /// <summary>
        /// Вес.
        /// </summary>
        public decimal? Weight { get; init; }

        /// <summary>
        /// Дата и время забора.
        /// </summary>
        public DateTimeOffset? PickupDate { get; init; }
    }
}