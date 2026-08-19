using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Host.Filters;

/// <summary>
/// Фильтр для обработки исключений валидации.
/// </summary>
public sealed class ValidationExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is not ValidationException ex)
        {
            return;
        }

        var problem = new ValidationProblemDetails()
        {
            Status = StatusCodes.Status400BadRequest,
            Title = ex.Message,
        };

        context.Result = new BadRequestObjectResult(problem);
        context.ExceptionHandled = true;
    }
}