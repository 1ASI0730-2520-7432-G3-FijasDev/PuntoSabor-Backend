namespace PuntoSabor_Backend.Shared.Domain.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> ListAsync(CancellationToken ct = default);
    Task AddAsync(T entity, CancellationToken ct = default);
}