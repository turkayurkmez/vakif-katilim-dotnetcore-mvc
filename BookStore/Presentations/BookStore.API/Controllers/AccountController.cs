using BookStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.ValidateUser(model.UserName, model.Password);
                if (user != null)
                {
                    SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bu-cumle-256-bitlik-bir-cumle-dikkat"));

                    SigningCredentials signing = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var claims = new Claim[]
                    {
                        new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Name,user.Name),
                        new Claim(ClaimTypes.Role,user.Role),

                    };

                    JwtSecurityToken token = new JwtSecurityToken(
                        issuer: "server.vakifkatilim",
                        audience: "client.vakifkatilim",
                        claims: claims,
                        notBefore: DateTime.UtcNow,
                        expires: DateTime.Now.AddDays(15),
                        signingCredentials: signing
                        );

                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                }

                return BadRequest(new { message = " Hatalı Giriş! " });
            }
            return BadRequest(ModelState);

        }
    }
}
