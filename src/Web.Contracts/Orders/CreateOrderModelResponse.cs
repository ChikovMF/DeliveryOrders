namespace Web.Contracts.Orders;

/// <summary>
/// Ответ на создание заказа.
/// </summary>
public sealed class CreateOrderModelResponse
{
    /// <summary>
    /// Номер заказа.
    /// </summary>
    public string? Number { get; init; }
}