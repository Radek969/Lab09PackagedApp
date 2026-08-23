using Microsoft.Extensions.Logging;

public class SerwisOperacji
{
    private readonly ILogger<SerwisOperacji> _logger;
    private readonly SerwisAutoryzacji _autoryzacja;

    public SerwisOperacji(
        ILogger<SerwisOperacji> logger,
        SerwisAutoryzacji autoryzacja)
    {
        _logger = logger;
        _autoryzacja = autoryzacja;
    }

    public void ObsluzSesje(
        string uzytkownik,
        string ip)
    {
        using (_logger.BeginScope(
            new Dictionary<string, object>
            {
                ["SesjaId"] =
                    Guid.NewGuid().ToString()[..8],

                ["Uzytkownik"] =
                    uzytkownik,

                ["Ip"] =
                    ip
            }))
        {
            _logger.LogInformation(
                "Rozpoczęcie sesji");

            bool ok =
                _autoryzacja.Zaloguj(
                    uzytkownik,
                    ip);

            if (!ok)
            {
                _logger.LogWarning(
                    "Brak autoryzacji - koniec sesji");

                return;
            }

            _logger.LogInformation(
                "Sesja zakończona pomyślnie");
        }
    }
}