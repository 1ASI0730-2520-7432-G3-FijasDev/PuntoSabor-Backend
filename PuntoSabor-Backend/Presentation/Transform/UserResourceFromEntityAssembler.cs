using PuntoSabor_Backend.Auth.Domain.Model;
using PuntoSabor_Backend.Presentation.Resources;

namespace PuntoSabor_Backend.Presentation.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
        => new(
            entity.Id,
            entity.Name,
            entity.Email,
            entity.CreatedAt,
            entity.UpdatedAt
        );
}