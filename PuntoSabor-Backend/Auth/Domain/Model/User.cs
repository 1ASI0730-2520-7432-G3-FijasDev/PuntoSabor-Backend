using PuntoSabor_Backend.Shared.Domain.Model;

namespace PuntoSabor_Backend.Auth.Domain.Model;

public class User : AuditableEntity
{
    
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    
}