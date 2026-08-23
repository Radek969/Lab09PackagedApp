using KanbanSystem.Application.Interfaces;
using KanbanSystem.Domain;
using KanbanSystem.Domain.ValueObjects;

namespace KanbanSystem.Application.Cards;

public sealed class CreateCardHandler
{
    private readonly ICardRepository _repo;
    private readonly IUnitOfWork _uow;

    public CreateCardHandler(
        ICardRepository repo,
        IUnitOfWork uow)
    {
        _repo = repo;
        _uow = uow;
    }

    public async Task<CreateCardResult> Handle(
        CreateCardCommand req,
        CancellationToken ct = default)
    {
        var priority =
            CardPriority.FromLevel(req.PriorityLevel);

        var card =
            Card.Create(
                req.Title,
                priority,
                req.ColumnId);

        await _repo.AddAsync(card, ct);

        await _uow.SaveChangesAsync(ct);

        return new CreateCardResult(
            card.Id,
            card.CreatedAt);
    }
}