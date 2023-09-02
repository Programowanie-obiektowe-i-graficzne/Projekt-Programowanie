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
    public class PatternController : Controller
    {
        private readonly IPatternRepository _patternRepository;
        private readonly IMapper _mapper;
        public PatternController(IPatternRepository patternRepository, IMapper mapper)
        {
            _patternRepository = patternRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pytanie>))]
        public IActionResult GetWzory()
        {
            var wzory = _mapper.Map<List<WzorDTO>>(_patternRepository.getWzory());
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
            var wzory = _mapper.Map<List<WzorDTO>>(_patternRepository.GetWzoryWielkosc(patternSize));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(wzory);
        }
    }
}
