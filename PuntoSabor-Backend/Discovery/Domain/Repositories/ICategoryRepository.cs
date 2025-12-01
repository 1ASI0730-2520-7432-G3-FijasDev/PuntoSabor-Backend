using PuntoSabor_Backend.Discovery.Domain.Model;

namespace PuntoSabor_Backend.Discovery.Domain.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> ListAsync(CancellationToken ct = default);
}