using Application.Dtos.Input;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BecksAcoesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthenticationAppService authenticationAppService) : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Authenticate([FromBody] LoginDto credentials)
    {
        if (credentials == null || string.IsNullOrWhiteSpace(credentials.UserName) || string.IsNullOrWhiteSpace(credentials.Password))
            return BadRequest("Invalid credentials.");

        // Here you would typically validate the credentials against a database or an external service.
        if (!authenticationAppService.Authenticate(credentials))
            return Unauthorized("Invalid username or password.");

        var claims = new[]
            {
                new Claim("Ordinary", "EveryoneButTheOwner")
            };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("myDefaultSuperSecretKeyabcdefghi"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "myDefaultIssuer",
            audience: "myDefaultAudience",
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds);

        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
    }
}