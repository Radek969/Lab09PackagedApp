public class ValidateStep : IBuildStep
{
    public async Task ExecuteAsync(
        BuildContext context,
        Func<Task> next)
    {
        context.Log.Add("Walidacja rozpoczęta");

        await Task.Delay(100);

        if (string.IsNullOrWhiteSpace(context.ProjectPath))
        {
            context.Success = false;
            context.ErrorMessage =
                "Brak ścieżki projektu";

            context.Log.Add(
                "BŁĄD: Brak ścieżki projektu");

            return;
        }

        context.Log.Add(
            "Walidacja zakończona pomyślnie");

        await next();
    }
}