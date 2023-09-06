using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pytanie>))]
        public IActionResult GetPytania()
        {
            var pytania = _questionRepository.getPytania();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pytania);
        }
        [HttpGet("{questionDifficulty}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pytanie>))]
        [ProducesResponseType(400)]
        public IActionResult GetPytaniaTrudnosc(int questionDifficulty)
        {
            var pytania = _questionRepository.GetPytaniaTrudnosc(questionDifficulty);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pytania);
        }
        [HttpGet("{questionAnswer}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pytanie>))]
        [ProducesResponseType(400)]
        public IActionResult GetPytaniaOdpowiedz(Slowo questionAnswer)
        {
            var pytania = _questionRepository.GetPytaniaOdpowiedz(questionAnswer);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pytania);
        }

    }
}
