using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_Programowanie.Data;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.MODELS;
using Projekt_Programowanie.Repository;

namespace Projekt_Programowanie.Controllers
{
    public class WordController : Controller
    {
        private readonly IWordRepository _wordRepository;
        public WordController(IWordRepository wordRepository, DataContext context)
        {
            _wordRepository = wordRepository;

        }
        public async Task<IActionResult> Word()
        {
            var slowa = await _wordRepository.GetSlowa();
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
        [HttpPost("Word/DodajSlowo")]
        public IActionResult DodajSlowo(Slowo slowo)
        {
            try
            {
                _wordRepository.Add(slowo);
                _wordRepository.Save();
                return RedirectToAction("Word");
            }
            catch (DbUpdateException ex)
            {
                 ModelState.AddModelError("", "Wystąpił błąd zapisu do bazy danych: " + ex.Message);
            }
            return View(slowo);
        }
        [HttpGet("Word/DodajSlowo")]
        public IActionResult DodajSlowo()
        {
            return View();
        }
        [HttpGet("Word/Edytuj/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var slowo = await _wordRepository.GetSlowo(id);

            if (slowo == null)
            {
                return NotFound(); // Jeśli słowo nie istnieje, zwróć NotFound
            }

            return View(slowo);
        }

        [HttpPost("Word/PotwierdzEdytuj")]
        public async Task<IActionResult> PotwierdzEdytuj(Slowo slowo)
        {

            _wordRepository.Update(slowo);
            return RedirectToAction("Word");
        }
        [HttpGet("Word/Usun/{id}")]
        public async Task<IActionResult> Usun(int id)
        {
            var slowo = await _wordRepository.GetSlowo(id);

            if (slowo == null)
            {
                return NotFound(); // Jeśli słowo nie istnieje, zwróć NotFound
            }

            return View(slowo);
        }

        [HttpPost("Word/PotwierdzUsuniecie")]
        public IActionResult PotwierdzUsuniecie(Slowo slowo)
        {
            var success = _wordRepository.Delete(slowo.ID_Slowa);

            if (success)
            {
                return RedirectToAction("Word"); // Przekieruj na listę słów lub inną stronę
            }
            else
            {
                return NotFound(); // W razie problemów, np. braku słowa do usunięcia
            }
        }
    }
}
