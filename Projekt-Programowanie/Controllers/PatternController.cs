using Microsoft.AspNetCore.Mvc;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.MODELS;

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
    }
}
