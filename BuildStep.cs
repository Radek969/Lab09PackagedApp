public class BuildStep : IBuildStep
{
    public async Task ExecuteAsync(
        BuildContext context,
        Func<Task> next)
    {
        context.Log.Add("Build rozpoczęty");

        await Task.Delay(200);

        context.OutputPath =
            $"{context.ProjectPath}/bin/{context.Configuration}";

        context.Log.Add("Build zakończony");

        await next();
    }
}