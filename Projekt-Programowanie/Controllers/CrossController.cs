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
            if (!string.IsNullOrEmpty(krzyzowka.Odpowiedz1))
            {
                krzyzowka.RozwiazywanaKrzyzowka = _crossRepository.wprowadzenieSlowa("wanna", krzyzowka.RozwiazywanaKrzyzowka, 101006);
            }

            TempData["krzyzowka"] = krzyzowka; // Zachowaj stan krzyzowka w TempData

            return RedirectToAction("Generator");
        }

        [HttpGet]
        public async Task<IActionResult> Generator()
        {
            GenerowanaKrzyzowka krzyzowka;

            if (TempData.ContainsKey("krzyzowka"))
            {
                krzyzowka = (GenerowanaKrzyzowka)TempData["krzyzowka"];
            }
            else
            {
                var tab = await _crossRepository.generowanie(2);
                krzyzowka = new GenerowanaKrzyzowka { RozwiazywanaKrzyzowka = tab.RozwiazywanaKrzyzowka };
            }

            return View(krzyzowka);
        }


    }

}
