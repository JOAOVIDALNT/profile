using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using profile.Application.DTOs.Article.Create;
using profile.Application.Services.Article;
using valet.lib.Auth.Service.Token.Middlewares;
using valet.lib.Core.Exception.Response;

namespace profile.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ArticleController : ControllerBase
{
    [ValidateUser]
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ArticleCreate([FromBody] ArticleCreateRequest request, [FromServices] IArticleService articleService)
    {
        var userId = HttpContext.User.FindFirst(ClaimTypes.Sid)?.Value;
        await articleService.Create(request, Guid.Parse(userId!));
        return Created(string.Empty, null);
    }
    
    [ValidateUser]
    [HttpGet("list")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ListArticles([FromServices] IArticleService articleService)
    {
        return Ok(await articleService.GetAllArticlesFromUser());
    }
    
}