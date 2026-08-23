public interface IBuildStep
{
    Task ExecuteAsync(
        BuildContext context,
        Func<Task> next);
}