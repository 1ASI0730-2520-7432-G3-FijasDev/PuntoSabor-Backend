using PuntoSabor_Backend.Discovery.Domain.Model;
using PuntoSabor_Backend.Presentation.Resources;

namespace PuntoSabor_Backend.Presentation.Transform;

public static class CreateHuariqueEntityFromResourceAssembler
{
    public static Huarique ToEntityFromResource(CreateHuariqueResource resource)
    {
        return new Huarique
        {
            Name = resource.Name.Trim(),
            District = resource.District.Trim(),
            CategoryId = resource.CategoryId,
            Price = resource.Price,
            
            Rating = 0,
            Near = false,
            Category = string.Empty
        };
    }
}