using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class WordController : Controller
    {
        private readonly IWordRepository _wordRepository;
        public WordController(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Slowo>))]
        public IActionResult GetSlowa()
        {
            var slowa = _wordRepository.getSlowa();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(slowa);
        }
    }
}
