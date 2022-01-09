using FilRouge.Interfaces;
using FilRouge.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilRouge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        IRepository<Tag> _tagRepository;
        IRepository<Question> _questionRepository;

        public TagController(IRepository<Tag> tagRepository, IRepository<Question> questionRepository)
        {
            _tagRepository = tagRepository;
            _questionRepository = questionRepository;
        }
    }
}
