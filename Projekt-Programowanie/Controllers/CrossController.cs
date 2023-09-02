using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.DTO;
using Projekt_Programowanie.Models.MODELS;
using Projekt_Programowanie.Repository;

namespace Projekt_Programowanie.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class CrossController : Controller
    {
        private readonly ICrossRepository _crossRepository;
        private readonly IMapper _mapper;
        public CrossController(ICrossRepository crossRepository, IMapper mapper)
        {
            _crossRepository = crossRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Krzyzowka>))]
        public IActionResult GetKrzyzowki()
        {
            var krzyzowki = _mapper.Map<List<KrzyzowkaDTO>>(_crossRepository.getKrzyzowki());
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
            var krzyzowka = _mapper.Map<Krzyzowka>(_crossRepository.GetKrzyzowka(crossId));
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
            var krzyzowki = _mapper.Map<List<KrzyzowkaDTO>>(_crossRepository.GetKrzyzowkiTrudnosc(crossDifficulty));
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
            var krzyzowki = _mapper.Map<List<KrzyzowkaDTO>>(_crossRepository.GetKrzyzowkiWzor(crossPattern));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(krzyzowki);
        }
    }
}
