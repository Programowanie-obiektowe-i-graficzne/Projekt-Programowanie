using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.MODELS;
using Projekt_Programowanie.Repository;

namespace Projekt_Programowanie.Controllers
{
    public class TableController : Controller
    {
        private readonly ITableRepository _tableRepository;

        public TableController(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;

        }
        public async Task<IActionResult> GetTabelaWynikow()
        {
            var tabela = await _tableRepository.GetTabelaWynikow();
            return Ok(tabela);
        }
        public async Task<IActionResult> GetWynikiUzytkownik(Uzytkownik tableUser)
        {
            var tabela = await _tableRepository.GetWynikiUzytkownik(tableUser);
            return Ok(tabela);
        }
    }
}
