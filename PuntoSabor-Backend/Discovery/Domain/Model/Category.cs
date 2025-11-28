using PuntoSabor_Backend.Shared.Domain.Model;

namespace PuntoSabor_Backend.Discovery.Domain.Model;

public class Category : AuditableEntity
{
    public string Name { get; set; } = null!;
}