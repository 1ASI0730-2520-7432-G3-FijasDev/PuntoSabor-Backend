namespace PuntoSabor_Backend.Presentation.Resources;

public record CreateHuariqueResource(
    string Name,
    string Category,
    int CategoryId,
    decimal Price,
    double Rating,
    string District,
    bool Near
);