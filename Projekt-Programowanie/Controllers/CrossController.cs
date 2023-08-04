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
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pytanie>))]
        public IActionResult GetWzory()
        {
            var wzory = _crossRepository.getWzory();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(wzory);
        }
    }
}
