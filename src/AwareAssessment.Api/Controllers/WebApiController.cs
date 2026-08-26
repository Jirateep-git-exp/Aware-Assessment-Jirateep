using AwareAssessment.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AwareAssessment.Api.Controllers;

[ApiController]
[Authorize(Roles = "User")]
[Route("api/web")]
public class WebApiController(IWebApiService webApiService) : ControllerBase
{
    [HttpGet("users/{id:int}")]
    public async Task<IActionResult> GetUser(int id, CancellationToken cancellationToken)
    {
        var result = await webApiService.GetUserAsync(id, cancellationToken);
        return Ok(result);
    }
    [HttpGet("users")]
    public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
    {
        var result = await webApiService.GetUsersAsync(cancellationToken);
        return Ok(result);
    }
}
