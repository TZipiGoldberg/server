using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SdcP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("login")]
        public IActionResult Login(string userId, string userName)
        {
            var token = GenerateJwtToken(userId, userName);
            return Ok(new { token });
        }

        private string GenerateJwtToken(string userId, string userName)
        {
            var now = DateTime.UtcNow;
            var secret = _configuration.GetValue<string>("Secret");
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));

            var userClaims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim(ClaimTypes.NameIdentifier, userId),
            };

            var expires = now.Add(TimeSpan.FromMinutes(60));
            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));

            var jwt = new JwtSecurityToken(
                    notBefore: now,
                    claims: userClaims,
                    expires: expires,
                    audience: _configuration.GetValue<string>("ClientUrl"),
                    issuer: _configuration.GetValue<string>("ClientUrl"),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            return  new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
