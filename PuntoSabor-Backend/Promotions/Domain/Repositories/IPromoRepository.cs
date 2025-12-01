using PuntoSabor_Backend.Promotions.Domain.Model;

namespace PuntoSabor_Backend.Promotions.Domain.Repositories;

public interface IPromoRepository
{
    Task<IEnumerable<Promo>> ListAsync(CancellationToken ct = default);
}