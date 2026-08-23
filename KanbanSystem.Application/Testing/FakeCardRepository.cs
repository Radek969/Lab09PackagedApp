using KanbanSystem.Application.Interfaces;
using KanbanSystem.Domain;

namespace KanbanSystem.Application.Testing;

public class FakeCardRepository : ICardRepository
{
    private readonly List<Card> _cards = [];

    public Task<Card?> GetByIdAsync(
        Guid id,
        CancellationToken ct = default)
    {
        var card = _cards.FirstOrDefault(
            x => x.Id == id);

        return Task.FromResult(card);
    }

    public Task AddAsync(
        Card card,
        CancellationToken ct = default)
    {
        _cards.Add(card);

        return Task.CompletedTask;
    }

    public IReadOnlyList<Card> Cards =>
        _cards;
}