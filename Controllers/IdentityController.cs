using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SistemaNH.Models.DAO;
using SistemaNH.Models.DTO;


namespace SistemaNH.Controllers
{
    [ApiController]
    [Route("apiIdentity")]
    public class IdentityController : ControllerBase
    {
        private readonly IConfiguration _cfg;
        private readonly UserDAO _userDao;

        public IdentityController(IConfiguration cfg, UserDAO userDao) {
            _cfg = cfg;
            _userDao = userDao;
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] Usuario user) {
            user = _userDao.Login(user);
            return user.Estado == 1 ? CreateToken(user) : Unauthorized();
        }

        public IActionResult CreateToken(Usuario user) {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, (user.Id + user.Email)),
                new Claim(JwtRegisteredClaimNames.Jti, System.Guid.NewGuid().ToString()),
                new Claim("IdUser", user.Id),
                new Claim("Rol", user.Rol.Descripcion)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_cfg["Tokens:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var result = new JwtSecurityToken(_cfg["Tokens:Issuer"], _cfg["Tokens:Audience"], claims, 
                notBefore: DateTime.UtcNow ,expires: DateTime.UtcNow.AddHours(5), signingCredentials: credentials);
            var results = new {
                id = user.Id,
                nombres = user.Nombres,
                token = new {
                    id =  new JwtSecurityTokenHandler().WriteToken(result),
                    expiration = result.ValidTo
                }
            };
            return Ok(results);
        } 
    }
}
