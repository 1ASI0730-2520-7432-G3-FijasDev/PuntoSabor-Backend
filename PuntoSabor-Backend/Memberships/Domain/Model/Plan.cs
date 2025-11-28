namespace PuntoSabor_Backend.Memberships.Domain.Model;

public class Plan
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
}