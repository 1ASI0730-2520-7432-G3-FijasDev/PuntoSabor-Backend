using PuntoSabor_Backend.Shared.Domain.Model;

namespace PuntoSabor_Backend.Auth.Domain.Model;

/// <summary>
/// Representa a un usuario dentro del sistema, incluyendo su nombre y correo.
/// </summary>

public class User : AuditableEntity
{
    
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    
}