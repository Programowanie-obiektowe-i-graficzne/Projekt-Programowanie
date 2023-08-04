using Microsoft.AspNetCore.Mvc;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.MODELS;
using Projekt_Programowanie.Repository;

namespace Projekt_Programowanie.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class CrossController : Controller
    {
        private readonly ICrossRepository _crossRepository;
        public CrossController(ICrossRepository crossRepository)
        {
            _crossRepository = crossRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Krzyzowka>))]
        public IActionResult GetKrzyzowki()
        {
            var krzyzowki = _crossRepository.getKrzyzowki();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(krzyzowki);
        }
        [HttpGet("{crossId}")]
        [ProducesResponseType(200, Type=typeof(Krzyzowka))]
        [ProducesResponseType(400)]
        public IActionResult GetKrzyzowka(int crossId)
        {
            if (!_crossRepository.KrzyzowkaExist(crossId))
            {
                return NotFound();
            }
            var krzyzowka = _crossRepository.GetKrzyzowka(crossId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(krzyzowka);
        }
        [HttpGet("{crossDificulty}")]
        [ProducesResponseType(200, Type = typeof(Krzyzowka))]
        [ProducesResponseType(400)]
        public IActionResult GetKrzyzowkiTrudnosc(int crossDifficulty)
        {
            var krzyzowki = _crossRepository.GetKrzyzowkiTrudnosc(crossDifficulty);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(krzyzowki);
        }
        [HttpGet("{crossPattern}")]
        [ProducesResponseType(200, Type = typeof(Krzyzowka))]
        [ProducesResponseType(400)]
        public IActionResult GetKrzyzowkiWzor(Wzor crossPattern)
        {
            var krzyzowki = _crossRepository.GetKrzyzowkiWzor(crossPattern);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(krzyzowki);
        }
    }
}
