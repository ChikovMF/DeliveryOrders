using System.Diagnostics.CodeAnalysis;

namespace Domain.Orders;

/// <summary>
/// Номер заказа.
/// </summary>
public sealed record OrderNumber
{
    private const char Delimiter = '_';
    private const string Prefix = "order";

    private readonly string _value;

    private OrderNumber(string value)
    {
        _value = value;
    }

    /// <summary>
    /// Сгенерировать новый номер заказа.
    /// </summary>
    public static OrderNumber New()
    {
        return new OrderNumber(Guid.CreateVersion7().ToString("N"));
    }

    /// <summary>
    /// Распарсить номер заказа.
    /// </summary>
    /// <exception cref="FormatException">Неверный формат номера заказа.</exception>
    public static OrderNumber Parse(string? text)
        => TryParse(text, out var result)
            ? result
            : throw new FormatException($"Неверный формат номера заказа: {text}");

    /// <summary>
    /// Попробовать распарсить номер заказа.
    /// </summary>
    public static bool TryParse(
        string? text,
        [NotNullWhen(true)] out OrderNumber? result)
    {
        result = null;

        if (string.IsNullOrEmpty(text))
        {
            return false;
        }

        if (!text.StartsWith($"{Prefix}{Delimiter}"))
        {
            return false;
        }

        if (text.Count(c => c == Delimiter) != 1)
        {
            return false;
        }

        var pieces = text.Split(Delimiter);

        if (string.IsNullOrWhiteSpace(pieces.Last()))
        {
            return false;
        }

        result = new OrderNumber(pieces.Last());
        return true;
    }

    public override string ToString() => $"{Prefix}{Delimiter}{_value}";
}