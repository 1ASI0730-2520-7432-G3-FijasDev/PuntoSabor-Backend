using PuntoSabor_Backend.Auth.Domain.Model;
using PuntoSabor_Backend.Presentation.Resources;

namespace PuntoSabor_Backend.Presentation.Transform;

public static class CreateUserEntityFromResourceAssembler
{
    public static User ToEntityFromResource(CreateUserResource resource)
        => new()
        {
            Name = resource.Name.Trim(),
            Email = resource.Email.Trim()
        };
}
