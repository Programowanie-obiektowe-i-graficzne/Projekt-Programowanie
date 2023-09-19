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

        public async Task<IActionResult> Generator()
        {
            var tab = await _crossRepository.generowanie(2);
            string data1 = HttpContext.Request.Form["odp1"];
            string data2 = HttpContext.Request.Form["odp2"];
            string data3 = HttpContext.Request.Form["odp3"];
            string data4 = HttpContext.Request.Form["odp4"];
            string data5 = HttpContext.Request.Form["odp5"];
            string data6 = HttpContext.Request.Form["odp6"];
            if (data1 != null)
                tab = _crossRepository.wprowadzenieSlowa(data1, tab, 100016);
            if (data2 != null)
                tab = _crossRepository.wprowadzenieSlowa(data2, tab, 201005);
            if (data3 != null)
                tab = _crossRepository.wprowadzenieSlowa(data3, tab, 100037);
            if (data4 != null)
                tab = _crossRepository.wprowadzenieSlowa(data4, tab, 204006);
            if (data5 != null)
                tab = _crossRepository.wprowadzenieSlowa(data5, tab, 102057);
            if (data6 != null)
                tab = _crossRepository.wprowadzenieSlowa(data6, tab, 206025);
            return View(tab);
        }
        public IActionResult Sprawdzam(GenerowanaKrzyzowka tab)
        {
            if (_crossRepository.sprawdzanie(tab) == true)
            {
                return View("Gratulacje"); // Przekierowanie do widoku gratulacyjnego
            }
            return View("Zla"); 
        }
        public IActionResult Gratulecje()
        {
            return View();
        }
        public IActionResult Zla()
        {
            return View();
        }
    }
    }
