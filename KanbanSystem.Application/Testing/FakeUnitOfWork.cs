using KanbanSystem.Application.Interfaces;

namespace KanbanSystem.Application.Testing;

public class FakeUnitOfWork : IUnitOfWork
{
    public bool Saved { get; private set; }

    public Task<int> SaveChangesAsync(
        CancellationToken ct = default)
    {
        Saved = true;

        return Task.FromResult(1);
    }
}