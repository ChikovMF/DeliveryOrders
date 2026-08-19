using System.Diagnostics.CodeAnalysis;
using Application.Orders;
using Web.Contracts.Orders;

namespace Web.Host.Converters;

public static class OrderConverter
{
    public static bool TryConvert(
        this CreateOrderModelRequest? request,
        [NotNullWhen(true)] out CreateOrderCommand? command,
        [NotNullWhen(false)] out IReadOnlyList<string>? errors)
    {
        command = null;
        errors = null;

        if (request is null)
        {
            errors = new[] { "Запрос не может быть пустым" };
            return false;
        }

        var errorsList = new List<string>();

        if (string.IsNullOrWhiteSpace(request.SenderCity))
        {
            errorsList.Add("Город отправителя не может быть пустым");
        }

        if (string.IsNullOrWhiteSpace(request.SenderAddress))
        {
            errorsList.Add("Адрес отправителя не может быть пустым");
        }

        if (string.IsNullOrWhiteSpace(request.RecipientCity))
        {
            errorsList.Add("Город получателя не может быть пустым");
        }

        if (string.IsNullOrWhiteSpace(request.RecipientAddress))
        {
            errorsList.Add("Адрес получателя не может быть пустым");
        }

        if (request.Weight is null)
        {
            errorsList.Add("Вес посылки не может быть пустым");
        }

        if (request.PickupDate is null)
        {
            errorsList.Add("Дата и время забора не может быть пустым");
        }

        if (errorsList.Count > 0)
        {
            errors = errorsList;
            return false;
        }

        command = new CreateOrderCommand(
            request.SenderCity!,
            request.SenderAddress!,
            request.RecipientCity!,
            request.RecipientAddress!,
            request.Weight!.Value,
            request.PickupDate!.Value);

        return true;
    }
}