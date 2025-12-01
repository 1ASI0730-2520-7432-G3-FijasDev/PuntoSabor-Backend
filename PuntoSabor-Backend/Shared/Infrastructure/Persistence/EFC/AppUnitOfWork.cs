using PuntoSabor_Backend.Shared.Domain.Repositories;

namespace PuntoSabor_Backend.Shared.Infrastructure.Persistence.EFC;

public class AppUnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync(CancellationToken ct = default)
    {
        await context.SaveChangesAsync(ct);
    }
}