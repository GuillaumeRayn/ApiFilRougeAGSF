using FilRouge.Interfaces;
using FilRouge.Model;
using FilRouge.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FilRouge.Controllers
{
    [EnableCors("allConnections")]
    [Route("api/users")]
    public class UserController : Controller
    {
        IRepository<User> _userRepository;
        LoginService _loginService;

        public UserController(IRepository<User> repository, LoginService loginService)
        {
            _userRepository = repository;
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult SubmitFormLogin([FromForm] string userName, [FromForm] string password)
        {
            string token = _loginService.GenerateToken(userName, password);
            if (token != null)
            {
                return Ok(new { Token = token });
            }
            return NotFound();
        }

        [HttpPost("register")]
        public IActionResult SubmitForm([FromForm] string username, [FromForm] string email, [FromForm] string password, [FromForm] string avatar)
        {
            User user = new User()
            {
                UserName = username,
                Email = email,
                Password = password,
                Avatar = avatar
            };
            ;
            if (_userRepository.Save(user) != null)
            {
                return Ok(new { Message = "user added", user = user });
            }
            return Ok(new { Message = "Error insertion" });
        }
    }
}
