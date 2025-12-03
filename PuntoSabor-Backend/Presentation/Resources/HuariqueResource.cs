namespace PuntoSabor_Backend.Presentation.Resources;

public record HuariqueResource(
    int Id,
    string Name,
    string Category,
    int CategoryId,
    decimal Price,
    double Rating,
    string District,
    bool Near,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);