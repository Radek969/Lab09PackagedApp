public class RestoreStep : IBuildStep
{
    public async Task ExecuteAsync(
        BuildContext context,
        Func<Task> next)
    {
        context.Log.Add("Restore rozpoczęty");

        await Task.Delay(200);

        context.Log.Add("Restore zakończony");

        await next();
    }
}