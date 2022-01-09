using FilRouge.Interfaces;
using FilRouge.Model;
using Microsoft.AspNetCore.Mvc;

namespace FilRouge.Controllers
{
    [Route("api/v1/answers")]
    public class AnswerController : Controller
    {
        IRepository<Answer> _answerRepository;
        IRepository<Question> _questionRepository;


        public AnswerController(IRepository<Answer> answerRepository, IRepository<Question> quesitonRepository)
        {
            _answerRepository = answerRepository;
            _questionRepository = quesitonRepository;
        }

        [HttpGet("{questionId}")]
        public IActionResult Get(int questionId)
        {
            Question q = _questionRepository.Get(questionId);
            if (q != null)
            {

                return Ok(q);
            }
            return NotFound();
        }
    }
}
