namespace PuntoSabor_Backend.Shared.Domain.Model;

public abstract class AuditableEntity
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}