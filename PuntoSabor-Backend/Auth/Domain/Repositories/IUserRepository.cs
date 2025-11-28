using PuntoSabor_Backend.Auth.Domain.Model;

namespace PuntoSabor_Backend.Auth.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> FindByEmailAsync(
        string? email,
        CancellationToken ct = default);

    Task AddAsync(
        User user,
        CancellationToken ct = default);
}