Console.WriteLine("=== Ćwiczenie 3.1 ===");

var context = new BuildContext
{
    ProjectPath = "C:/Projects/Test",
    Configuration = "Release"
};

var pipeline = new BuildPipeline()
    .AddStep(new ValidateStep())
    .AddStep(new RestoreStep())
    .AddStep(new TestStep())
    .AddStep(new BuildStep());

await pipeline.ExecuteAsync(context);

Console.WriteLine();

Console.WriteLine("=== LOG ===");

foreach (var log in context.Log)
{
    Console.WriteLine(log);
}

Console.WriteLine();

Console.WriteLine($"Status: {context.Success}");
Console.WriteLine($"Output: {context.OutputPath}");
Console.WriteLine();
Console.WriteLine("=== Ćwiczenie 4.1 - Kanban ===");

var repository =
    new KanbanSystem.Application.Testing.FakeCardRepository();

var unitOfWork =
    new KanbanSystem.Application.Testing.FakeUnitOfWork();

var handler =
    new KanbanSystem.Application.Cards.CreateCardHandler(
        repository,
        unitOfWork);

var command =
    new KanbanSystem.Application.Cards.CreateCardCommand(
        "Implementacja logowania",
        3,
        Guid.NewGuid());

var result =
    await handler.Handle(command);

Console.WriteLine(
    $"Utworzono kartę: {result.CardId}");

Console.WriteLine(
    $"Data utworzenia: {result.CreatedAt}");

Console.WriteLine(
    $"Liczba kart w repozytorium: " +
    $"{repository.Cards.Count}");

Console.WriteLine(
    $"Zapisano zmiany: {unitOfWork.Saved}");