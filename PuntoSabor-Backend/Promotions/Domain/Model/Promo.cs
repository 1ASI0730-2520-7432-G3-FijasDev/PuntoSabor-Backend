using PuntoSabor_Backend.Shared.Domain.Model;

namespace PuntoSabor_Backend.Promotions.Domain.Model;

public class Promo : AuditableEntity
{
    
    public string Title { get; set; } = null!;
    
    public string Note { get; set; } = null!;
    
}