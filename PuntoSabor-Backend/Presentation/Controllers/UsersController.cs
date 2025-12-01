using Microsoft.AspNetCore.Mvc;
using PuntoSabor_Backend.Auth.Domain.Model;
using PuntoSabor_Backend.Auth.Domain.Repositories;
using PuntoSabor_Backend.Shared.Domain.Repositories;

namespace PuntoSabor_Backend.Presentation.Controllers;

[ApiController]
[Route("users")]
public class UsersController(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork) : ControllerBase
{
    /// <summary>
    /// Devuelve usuarios filtrando por email.
    /// GET /users?email=correo@example.com
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get(
        [FromQuery] string? email,
        CancellationToken ct)
    {
        var result = await userRepository.FindByEmailAsync(email, ct);
        return Ok(result);
    }

    /// <summary>
    /// Registra un nuevo usuario.
    /// POST /users
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<User>> Create(
        [FromBody] User dto,
        CancellationToken ct)
    {
        await userRepository.AddAsync(dto, ct);   // ⬅️ solo aquí usamos AddAsync
        await unitOfWork.CompleteAsync(ct);

        return StatusCode(StatusCodes.Status201Created, dto);
    }
}