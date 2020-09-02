using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SistemaNH.Models.DAO;
using SistemaNH.Models.DTO;


namespace SistemaNH.Controllers
{
    [ApiController]
    [Route("apiIdentity/usuario")]
    [Authorize(Policy = "Administradores")]
    public class UserController : ControllerBase
    {
        private readonly UserDAO _userDao;

        public UserController(UserDAO userDao) {
            _userDao = userDao;
        }

        [Route("all")]
        [HttpGet]
        public IActionResult GetUsuarios() {
            var usuarios = _userDao.GetUsuarios();
            if(usuarios.Count > 0)
                return Ok(usuarios);
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetUsuario(string id) {
            var user = _userDao.GetUsuario(id);
            if(!string.IsNullOrEmpty(user.Id))
                return Ok(user);
            return NotFound();
        }  

        [Route("add")]
        [HttpPost]
        public IActionResult AddUser(User user) {
            var result = _userDao.AddUser(user);
            if(result) 
                return Ok();
            return BadRequest();
        }      

        [Route("enabled")]
        [HttpPost]
        public IActionResult Enabled(string id) {
            var result = _userDao.Enabled(id);
            if(result)
                return Ok();
            return BadRequest();
        }

        [Route("disabled")]
        [HttpPost]
        public IActionResult Disabled(string id) {
            var result = _userDao.Disabled(id);
            if(result)
                return Ok();
            return BadRequest();
        }
    }
}
