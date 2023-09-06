using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.MODELS;
using Projekt_Programowanie.Repository;

namespace Projekt_Programowanie.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class PatternController : Controller
    {
        private readonly IPatternRepository _patternRepository;

        public PatternController(IPatternRepository patternRepository)
        {
            _patternRepository = patternRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pytanie>))]
        public IActionResult GetWzory()
        {
            var wzory = _patternRepository.getWzory();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(wzory);
        }
        [HttpGet("{patternSize}")]
        [ProducesResponseType(200, Type = typeof(Wzor))]
        [ProducesResponseType(400)]
        public IActionResult GetWzoryWielkosc(int patternSize)
        {
            var wzory = _patternRepository.GetWzoryWielkosc(patternSize);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(wzory);
        }
    }
}
