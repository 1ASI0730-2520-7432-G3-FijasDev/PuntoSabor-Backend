using Microsoft.EntityFrameworkCore;
using PuntoSabor_Backend.Memberships.Domain.Model;
using PuntoSabor_Backend.Memberships.Domain.Repositories;
using PuntoSabor_Backend.Shared.Infrastructure.Persistence.EFC;

namespace PuntoSabor_Backend.Memberships.Infrastructure.Persistence.EFC.Repositories;

public class PlanRepository(AppDbContext context) : IPlanRepository
{
    
    public async Task<IEnumerable<Plan>> ListAsync(CancellationToken ct = default)
    
    {
        return await context.Plans.AsNoTracking().ToListAsync(ct);
    }
}