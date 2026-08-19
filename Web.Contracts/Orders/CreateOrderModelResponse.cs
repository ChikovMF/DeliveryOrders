namespace Web.Contracts.Orders;

/// <summary>
/// Ответ на создание заказа.
/// </summary>
public sealed class CreateOrderModelResponse(string number)
{
    /// <summary>
    /// Номер заказа.
    /// </summary>
    public string Number { get; } = number;
}