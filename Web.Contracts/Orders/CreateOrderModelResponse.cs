namespace Web.Contracts.Orders;

/// <summary>
/// Ответ на создание заказа.
/// </summary>
public class CreateOrderModelResponse
{
    public CreateOrderModelResponse(string number)
    {
        Number = number;
    }

    /// <summary>
    /// Номер заказа.
    /// </summary>
    public string Number { get; set; }
}