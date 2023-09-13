using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_Programowanie.Data;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Controllers
{
    public class WordController : Controller
    {
        private readonly IWordRepository _wordRepository;
        private readonly DataContext _context;
        public WordController(IWordRepository wordRepository, DataContext context)
        {
            _wordRepository = wordRepository;
            _context = context;

        }
        public async Task<IActionResult> Word()
        {
            var slowa =await _wordRepository.GetSlowa();
            return View(slowa);
            
        }
        public async Task<IActionResult> GetSlowo(int wordId)
        {
            var slowo = await _wordRepository.GetSlowo(wordId);
            return View(slowo);
        }
        public async Task<IActionResult> GetSlowoDlugosc(int wordLength)
        {
            var slowa = await _wordRepository.GetSlowoDlugosc(wordLength);
            return View(slowa);
        }
        [HttpPost]
        public IActionResult DodajSlowo(Slowo slowo)
        {
            if (ModelState.IsValid)
            {
                _wordRepository.Add(slowo);
                _wordRepository.Save();
                return RedirectToAction("Index");
            }
            return View(slowo);
        }
        public IActionResult DodajSlowo()
        {
            return View();
        }
    }
}
