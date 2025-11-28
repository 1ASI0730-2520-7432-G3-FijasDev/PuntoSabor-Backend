namespace PuntoSabor_Backend.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync(CancellationToken ct = default);
}