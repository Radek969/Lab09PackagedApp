using KanbanSystem.Domain;

namespace KanbanSystem.Application.Interfaces;

public interface ICardRepository
{
    Task<Card?> GetByIdAsync(
        Guid id,
        CancellationToken ct = default);

    Task AddAsync(
        Card card,
        CancellationToken ct = default);
}