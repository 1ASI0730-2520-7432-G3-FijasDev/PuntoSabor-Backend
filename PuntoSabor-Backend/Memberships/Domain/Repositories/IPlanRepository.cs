using PuntoSabor_Backend.Memberships.Domain.Model;

namespace PuntoSabor_Backend.Memberships.Domain.Repositories;

public interface IPlanRepository
{
    Task<IEnumerable<Plan>> ListAsync(CancellationToken ct = default);
}