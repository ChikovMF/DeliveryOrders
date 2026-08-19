using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Store.Converters;

internal sealed class DateTimeOffsetConverter() : ValueConverter<DateTimeOffset, DateTimeOffset>(
    dto => dto.ToUniversalTime(),
    dto => dto.ToUniversalTime());

internal sealed class NullableDateTimeOffsetConverter() : ValueConverter<DateTimeOffset?, DateTimeOffset?>(
    dto => dto.HasValue ? dto.Value.ToUniversalTime() : dto,
    dto => dto.HasValue ? dto.Value.ToUniversalTime() : dto);