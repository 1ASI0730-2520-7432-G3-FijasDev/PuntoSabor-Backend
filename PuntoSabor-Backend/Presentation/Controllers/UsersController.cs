using Microsoft.AspNetCore.Mvc;
using PuntoSabor_Backend.Auth.Domain.Model;
using PuntoSabor_Backend.Auth.Domain.Repositories;
using PuntoSabor_Backend.Shared.Domain.Repositories;

namespace PuntoSabor_Backend.Presentation.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _users;
    private readonly IUnitOfWork _unitOfWork;

    public UsersController(IUserRepository users, IUnitOfWork unitOfWork)
    {
        _users = users;
        _unitOfWork = unitOfWork;
    }

    /// GET /users?email=demo@puntosabor.com
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get(
        [FromQuery] string? email,
        CancellationToken ct)
    {
        var result = await _users.FindByEmailAsync(email!, ct);
        return Ok(result); // 200 + JSON
    }

    /// POST /users
    [HttpPost]
    public async Task<ActionResult<User>> Create([FromBody] User dto, CancellationToken ct)
    {
        await _users.AddAsync(dto, ct);
        await _unitOfWork.CompleteAsync(ct);

        return CreatedAtAction(nameof(Get), new { email = dto.Email }, dto);
    }
}