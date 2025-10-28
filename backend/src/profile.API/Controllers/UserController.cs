using Microsoft.AspNetCore.Mvc;
using profile.Application.DTOs.User.Signup;
using profile.Application.Services.User;
using valet.lib.Core.Exception.Response;

namespace profile.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpPost("signup")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UserSignup([FromBody] UserSignupRequest request, [FromServices] IUserService userService)
    {
        await userService.Signup(request);
        return Created(string.Empty, null);
    }
}