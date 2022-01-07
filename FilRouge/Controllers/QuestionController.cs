using FilRouge.Interfaces;
using FilRouge.Model;
using Microsoft.AspNetCore.Mvc;

namespace FilRouge.Controllers
{
    [Route("api/v1/questions")]
    public class QuestionController : Controller
    {

        IRepository<Question> _questionRepository;
        
        public QuestionController(IRepository<Question> repository)
        {
            _questionRepository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_questionRepository.GetAll());
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
