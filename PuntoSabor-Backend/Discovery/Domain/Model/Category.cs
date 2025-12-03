using PuntoSabor_Backend.Shared.Domain.Model;

namespace PuntoSabor_Backend.Discovery.Domain.Model;

/// <summary>
/// Entidad base con Id, marcas de creación y actualización.
/// </summary>


public class Category : AuditableEntity
{
    public string Name { get; set; } = null!;
}