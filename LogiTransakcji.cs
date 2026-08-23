using Microsoft.Extensions.Logging;

public static partial class LogiTransakcji
{
    [LoggerMessage(
        EventId = 1001,
        Level = LogLevel.Information,
        Message = "Przelew {Kwota:C} od {Nadawca} do {Odbiorca}")]
    public static partial void Przelew(
        ILogger logger,
        decimal kwota,
        string nadawca,
        string odbiorca);

    [LoggerMessage(
        EventId = 1002,
        Level = LogLevel.Warning,
        Message = "Przelew wysokiej wartości {Kwota:C}")]
    public static partial void PrzelewWysokiejWartosci(
        ILogger logger,
        decimal kwota);
}