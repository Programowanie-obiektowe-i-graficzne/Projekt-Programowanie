using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projekt_Programowanie.Data;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models;
using Projekt_Programowanie.Models.MODELS;
using Projekt_Programowanie.Repository;

namespace Projekt_Programowanie.Controllers
{
    public class CrossController : Controller
    {
        private readonly ICrossRepository _crossRepository;
        public CrossController(ICrossRepository crossRepository)
        {
            _crossRepository = crossRepository;
        }
        public async Task<IActionResult> Cross()
        {
             var crosses = await _crossRepository.GetKrzyzowki();
            return View(crosses);
        }
        [HttpPost]
        public async Task<IActionResult> Generator(GenerowanaKrzyzowka krzyzowka)
        {
            krzyzowka = _crossRepository.wprowadzenieSlowa(krzyzowka.Odpowiedz1, krzyzowka, 100016);
            return RedirectToAction("Generator",krzyzowka);
        }
        [HttpGet]
        public async Task<IActionResult> Generator()
        {
            var tab = await _crossRepository.generowanie(2);
            return View(tab);
        }
    }
        
}
