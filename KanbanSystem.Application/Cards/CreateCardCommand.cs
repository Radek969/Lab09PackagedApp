namespace KanbanSystem.Application.Cards;

public sealed record CreateCardCommand(
    string Title,
    int PriorityLevel,
    Guid ColumnId);

public sealed record CreateCardResult(
    Guid CardId,
    DateTime CreatedAt);