using AwareAssessment.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Reflection.Metadata.Ecma335;

namespace AwareAssessment.Api.Controllers;

[ApiController]
[Authorize(Roles = "User")]
[Route("api/products")]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var products = await productService.GetProductsAsync(cancellationToken);
        return Ok(products);
    }
}
