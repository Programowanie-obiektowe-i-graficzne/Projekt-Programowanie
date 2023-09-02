using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.DTO;
using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class WordController : Controller
    {
        private readonly IWordRepository _wordRepository;
        private readonly IMapper _mapper;
        public WordController(IWordRepository wordRepository, IMapper mapper)
        {
            _wordRepository = wordRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Slowo>))]
        public IActionResult GetSlowa()
        {
            var slowa = _mapper.Map<List<SlowoDTO>>(_wordRepository.getSlowa());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(slowa);
        }
        [HttpGet("{wordId}")]
        [ProducesResponseType(200, Type = typeof(Slowo))]
        [ProducesResponseType(400)]
        public IActionResult GetSlowo(int wordId)
        {
            var slowo = _mapper.Map<Slowo>(_wordRepository.GetSlowo(wordId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(slowo);
        }
        [HttpGet("{wordLength}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Slowo>))]
        [ProducesResponseType(400)]
        public IActionResult GetSlowoDlugosc(int wordLength)
        {
            var slowa = _mapper.Map<List<SlowoDTO>>(_wordRepository.GetSlowoDlugosc(wordLength));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(slowa);
        }
    }
}
