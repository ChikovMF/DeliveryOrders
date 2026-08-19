using Application.Orders;
using Domain.Orders;
using Microsoft.AspNetCore.Mvc;
using Web.Contracts.Orders;
using Web.Host.Converters;
using Web.Host.Mappers;

namespace Web.Host.Controllers;

/// <summary>
/// Контроллер для работы с заказами.
/// </summary>
[ApiController]
[Route("api/orders")]
public sealed class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    /// <summary>
    /// Получить все паллеты
    /// </summary>
    [HttpGet]
    [ProducesResponseType<IReadOnlyCollection<OrderListModelResponse>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(
        CancellationToken cancellationToken,
        int offset = 0,
        int limit = 100)
    {
        var result = await _orderService.GetAllAsync(offset, limit, cancellationToken);

        return Ok(result.Select(o => o.ToResponse()).ToList());
    }

    /// <summary>
    /// Получить заказ по номеру.
    /// </summary>
    /// <response code="200">Данные получены</response>
    /// <response code="404">Заказ не найден</response>
    [HttpGet("{number}")]
    [ProducesResponseType<OrderModelResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync(
        [FromRoute] string number,
        CancellationToken cancellationToken)
    {
        if (!OrderNumber.TryParse(number, out var orderNumber))
        {
            return BadRequest("Некорректный номер заказа");
        }

        var result = await _orderService.GetAsync(orderNumber, cancellationToken);
        if (result is null)
        {
            return NotFound();
        }

        return Ok(result.ToResponse());
    }

    /// <summary>
    /// Создать заказ.
    /// </summary>
    /// <response code="201">Запись добавлена в БД</response>
    /// <response code="400">Ошибка валидации входных данных</response>
    [HttpPost]
    [ProducesResponseType<CreateOrderModelResponse>(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateOrderModelRequest request,
        CancellationToken cancellationToken)
    {
        if (!request.TryConvert(out var command, out var errors))
        {
            return BadRequest("Ошибка валидации входных данных: " + string.Join(", ", errors));
        }

        var orderNumber = await _orderService.CreateAsync(command, cancellationToken);
        var response = new CreateOrderModelResponse(orderNumber.ToString());
        return Ok(response);
    }
}