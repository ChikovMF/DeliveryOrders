namespace Application.Orders;

/// <summary>
/// Команда создания заказа.
/// </summary>
public sealed record CreateOrderCommand(
    string SenderCity,
    string SenderAddress,
    string RecipientCity,
    string RecipientAddress,
    decimal Weight,
    DateTimeOffset PickupDate);