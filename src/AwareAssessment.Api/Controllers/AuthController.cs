using AwareAssessment.Api.Auth;
using AwareAssessment.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AwareAssessment.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IOptions<JwtSettings> jwtOptions) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // Demo Users
        if (request.Username != "admin" || request.Password != "1234")
            return Unauthorized(new { message = "Invalid username or password." });

        var settings = jwtOptions.Value;
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, request.Username),
            new Claim(ClaimTypes.Role, "User")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Key));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.UtcNow.AddMinutes(settings.ExpiresMinutes);

        var token = new JwtSecurityToken(
            issuer: settings.Issuer,
            audience: settings.Audience,
            claims: claims,
            expires: expires,
            signingCredentials: credentials);

        return Ok(new LoginResponse
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(token)
        });
    }
}
