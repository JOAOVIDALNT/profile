using Microsoft.AspNetCore.Mvc;
using profile.Application.DTOs.Subscriber;
using profile.Application.DTOs.User.Register;
using profile.Application.Services.User;
using valet.lib.Core.Exception.Response;

namespace profile.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequest request, [FromServices] IUserService service)
    {
        await service.Register(request);
        return Created(string.Empty, null);
    }
    
    [HttpPost("subscribe")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Subscribe([FromBody] SubscribeRequest request, [FromServices] IUserService service)
    {
        await service.Subscribe(request);
        return Ok();
    }
}