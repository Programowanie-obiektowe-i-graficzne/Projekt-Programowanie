using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projekt_Programowanie.Data;
using Projekt_Programowanie.Interfaces;
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
            IEnumerable<Krzyzowka> crosses = await _crossRepository.GetKrzyzowki();
            return View(crosses);
        }
        public IActionResult Generate()
        {
            return View();
        }
        public async Task<IActionResult> Generate(Krzyzowka krzyzowka)
        {
            var tab = _crossRepository.generowanie(2);
            _crossRepository.Generate(krzyzowka);
            return View(tab);
        }
        public async Task<IActionResult> Generator()
        {
            var tab = _crossRepository.generowanie(2);
            return View(tab);
        }
    }
        
}
