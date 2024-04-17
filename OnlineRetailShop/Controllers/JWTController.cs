using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineRetailShop.Repository.Interface;
using OnlineRetailShop.Repository.Entity;
using OnlineRetailShop.Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineRetailShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : ControllerBase
    {
        private IConfiguration _config;
        private IAuthenticationServices _authenticationService;
        public JWTController(IConfiguration config,IAuthenticationServices authenticationService)
        {
            _config = config;
            _authenticationService = authenticationService;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("/Login")]
        public async Task<IActionResult> Login(Guid userid , string password)
        {
            //IActionResult response = Unauthorized();
            var user =(UserModel) await AuthenticateUser(userid, password);
            if (user != null)
            {
                var tokenString =GenerateJSONWebToken(user);
                return Ok(new { token = tokenString });
            }

            return NoContent();
        }

        private string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Name, userInfo.UserName),
                new Claim(JwtRegisteredClaimNames.Sub,userInfo.Password),
                new Claim("UserId", userInfo.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["JwtSettings:Issuer"],
                _config["JwtSettings:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<UserModel> AuthenticateUser(Guid userid, string password)
        {
            UserModel user = null;
            UserModel users = (UserModel) await _authenticationService.GetUser(userid);
            if (users.Password != password) return null;
            if (users != null)
            {
                user = new UserModel {UserId=users.UserId ,UserName = users.UserName, Password = users.Password };
            }
            return user;
        }
    }
}
