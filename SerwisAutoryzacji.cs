using Microsoft.Extensions.Logging;

public class SerwisAutoryzacji
{
    private readonly ILogger<SerwisAutoryzacji> _logger;

    public SerwisAutoryzacji(
        ILogger<SerwisAutoryzacji> logger)
    {
        _logger = logger;
    }

    public bool Zaloguj(
        string login,
        string adresIp)
    {
        _logger.LogInformation(
            "Próba logowania {Login} z {AdresIp}",
            login,
            adresIp);

        if (login == "admin" &&
            adresIp.StartsWith("192.168"))
        {
            _logger.LogInformation(
                "Użytkownik {Login} zalogowany pomyślnie",
                login);

            return true;
        }

        _logger.LogWarning(
            "Nieudane logowanie {Login} z {AdresIp}",
            login,
            adresIp);

        return false;
    }
}