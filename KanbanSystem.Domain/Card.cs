namespace KanbanSystem.Domain;

using KanbanSystem.Domain.ValueObjects;

public class Card
{
    public Guid Id { get; private set; }

    public string Title { get; private set; } = "";

    public CardPriority Priority { get; private set; } =
        CardPriority.Low;

    public Guid ColumnId { get; private set; }

    public DateTime CreatedAt { get; private set; }

    private Card()
    {
    }

    public static Card Create(
        string title,
        CardPriority priority,
        Guid columnId)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException(
                "Tytuł nie może być pusty.",
                nameof(title));
        }

        return new Card
        {
            Id = Guid.NewGuid(),
            Title = title,
            Priority = priority,
            ColumnId = columnId,
            CreatedAt = DateTime.UtcNow
        };
    }

    public void MoveToColumn(Guid newColumnId)
    {
        ColumnId = newColumnId;
    }
}