using Microsoft.AspNetCore.Mvc;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.MODELS;
using Projekt_Programowanie.Repository;

namespace Projekt_Programowanie.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class TableController : Controller
    {
        private readonly ITableRepository _tableRepository;
        public TableController(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository; 
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TabelaWynikow>))]
        public IActionResult GetTabelaWynikow()
        {
            var tabela = _tableRepository.getTabelaWynikow();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(tabela);
        }
        [HttpGet("{tableUser}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TabelaWynikow>))]
        [ProducesResponseType(400)]
        public IActionResult GetWynikiUzytkownik(Uzytkownik tableUser)
        {
            var tabela = _tableRepository.GetWynikiUzytkownik(tableUser);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(tabela);
        }
    }
}
