public class TestStep : IBuildStep
{
    public async Task ExecuteAsync(
        BuildContext context,
        Func<Task> next)
    {
        context.Log.Add("Testy rozpoczęte");

        await Task.Delay(200);

        bool testyPoprawne = true;

        if (!testyPoprawne)
        {
            context.Success = false;
            context.ErrorMessage = "Testy nie przeszły pomyślnie";

            context.Log.Add(
                $"BŁĄD: {context.ErrorMessage}");

            return;
        }

        context.Log.Add("Testy zakończone pomyślnie");

        await next();
    }
}