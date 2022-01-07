using Microsoft.AspNetCore.Mvc;

namespace FilRouge.Controllers
{
    [Route("api/v1/questions")]
    public class AnswerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
