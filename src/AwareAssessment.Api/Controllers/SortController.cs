using AwareAssessment.Api.Models;
using AwareAssessment.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AwareAssessment.Api.Controllers;

[ApiController]
[Route("api/sort")]
[Authorize(Roles = "User")]
public class SortController(ISortService sortService) : ControllerBase
{
    [HttpPost]
    public IActionResult Post([FromBody] SortRequest request)
    {
        if (request.P1.Length > 99)
            return BadRequest(new { message = "parameter1 must not exceed 99 characters." });

        if (string.IsNullOrWhiteSpace(request.P1))
            return BadRequest(new { message = "parameter1 is required." });

        var sorts = sortService.GetDuplicateSortedRanks(request.P1)
            .Select(value => new SortResponse { Sort = value })
            .ToList();

        return Ok(sorts);
    }
}
