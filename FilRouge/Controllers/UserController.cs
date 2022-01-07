using FilRouge.Interfaces;
using FilRouge.Model;
using Microsoft.AspNetCore.Mvc;

namespace FilRouge.Controllers
{
    [Route("api/v1/utilisateurs")]
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
        public IActionResult SubmitFormLogin([FromForm] string login, [FromForm] string password)
        {
            string token = _loginService.GenerateToken(login, password);
            if (token != null)
            {
                return Ok(new { Token = token });
            }
            return NotFound();
        }
    }
}
