namespace PuntoSabor_Backend.Presentation.Resources;

public record UserResource(
    int Id,
    string Name,
    string Email,
    DateTime CreatedAt,
    DateTime? UpdatedAt);