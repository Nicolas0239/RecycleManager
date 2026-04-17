using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace RecycleManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DevTokenController : ControllerBase
{
    private readonly IConfiguration _config;
    public DevTokenController(IConfiguration config) => _config = config;

    // Only in Development environment should be used.
    [HttpGet("token")]
    public IActionResult GetToken()
    {
        var jwt = _config.GetSection("JwtSettings");
        var key = Encoding.UTF8.GetBytes(jwt.GetValue<string>("Secret") ?? "DevSecretKey_ReplaceInProd_123456");
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "devuser"), new Claim(ClaimTypes.Role, "Admin") }),
            Expires = DateTime.UtcNow.AddHours(12),
            Issuer = jwt.GetValue<string>("Issuer"),
            Audience = jwt.GetValue<string>("Audience"),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Ok(new { token = tokenHandler.WriteToken(token) });
    }
}
