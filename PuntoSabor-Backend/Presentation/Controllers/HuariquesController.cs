using Microsoft.AspNetCore.Mvc;
using PuntoSabor_Backend.Discovery.Domain.Model;
using PuntoSabor_Backend.Discovery.Domain.Repositories;
using PuntoSabor_Backend.Shared.Domain.Repositories;

namespace PuntoSabor_Backend.Presentation.Controllers;

[ApiController]
[Route("huariques")]
public class HuariquesController(
    IHuariqueRepository huariques,
    IUnitOfWork unitOfWork) : ControllerBase
{
    /// <summary>
    /// Busca huariques por texto y/o cercanos.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Huarique>>> GetAll(
        [FromQuery] string? q,
        [FromQuery] bool? near,
        CancellationToken ct)
    {
        var result = await huariques.SearchAsync(q, near, ct);
        return Ok(result);
    }

    /// <summary>
    /// Devuelve el detalle de un huarique por id.
    /// GET /huariques/:id
    /// </summary>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Huarique>> GetById(int id, CancellationToken ct)
    {
        var item = await huariques.FindByIdAsync(id, ct);
        return item is null ? NotFound() : Ok(item);
    }

    /// <summary>
    /// Crea un nuevo huarique.
    /// POST /huariques
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<Huarique>> Create(
        [FromBody] Huarique dto,
        CancellationToken ct)
    {
        await huariques.AddAsync(dto, ct);
        await unitOfWork.CompleteAsync(ct);

        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    /// <summary>
    /// PATCH /huariques/:id
    /// </summary>
    [HttpPatch("{id:int}")]
    public async Task<ActionResult<Huarique>> Patch(
        int id,
        [FromBody] Dictionary<string, object> patch,
        CancellationToken ct)
    {
        var existing = await huariques.FindByIdAsync(id, ct);
        if (existing is null) return NotFound();

        await huariques.PatchAsync(existing, patch, ct);
        await unitOfWork.CompleteAsync(ct);

        return Ok(existing);
    }
}
