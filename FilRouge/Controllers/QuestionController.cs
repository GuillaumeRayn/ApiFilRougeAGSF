using FilRouge.Interfaces;
using FilRouge.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FilRouge.Controllers
{
    [EnableCors("allConnections")]
    [Route("api/questions")]
    public class QuestionController : Controller
    {

        IRepository<Question> _questionRepository;
        IRepository<Tag> _tagRepository;
        
        public QuestionController(IRepository<Question> repository, IRepository<Tag> tRepository)
        {
            _questionRepository = repository;
            _tagRepository = tRepository;
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

        [HttpPost("submitQuestion")]
        public IActionResult SubmitQuestion([FromForm] string tags, [FromForm] string title, [FromForm] string content)
        {

            Question q = new Question()
            { 
                Title = title,
                Content = content
            };
                q.Tags.Add(_tagRepository.SearchOne(T => T.Name == tags));
            
            if (_questionRepository.Save(q) != null)
            {
                return Ok(new { Message = "question added", question = q });
            }
            return Ok(new { Message = "Error insertion" });
        }
    }
}
