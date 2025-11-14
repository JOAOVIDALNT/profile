using Microsoft.AspNetCore.Mvc;
using profile.Application.DTOs.Auth.Login;
using profile.Application.Services.Auth;
using valet.lib.Core.Exception.Response;

namespace profile.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest request, [FromServices] IAuthService service)
    {
        return Ok(await service.Login(request));
    }
}