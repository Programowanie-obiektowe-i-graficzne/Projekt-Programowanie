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
    public class TableController : Controller
    {
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;
        public TableController(ITableRepository tableRepository, IMapper mapper)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TabelaWynikow>))]
        public IActionResult GetTabelaWynikow()
        {
            var tabela = _mapper.Map<List<TabelaWynikowDTO>>(_tableRepository.getTabelaWynikow());
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
            var tabela = _mapper.Map<List<TabelaWynikowDTO>>(_tableRepository.GetWynikiUzytkownik(tableUser));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(tabela);
        }
    }
}
