using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_Programowanie.Data;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.MODELS;
using Projekt_Programowanie.Repository;
using System.Collections.Generic;

namespace Projekt_Programowanie.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IWordRepository _wordRepository;
        public QuestionController(IQuestionRepository questionRepository, IWordRepository wordRepository)
        {
            _questionRepository = questionRepository;
            _wordRepository = wordRepository;
        }
        public async Task<IActionResult> GetPytaniaTrudnosc(int questionDifficulty)
        {
            IEnumerable<Pytanie> questions = await _questionRepository.GetPytaniaTrudnosc(questionDifficulty);
            return View(questions);
        }
        public async Task<IActionResult> GetPytaniaOdpowiedz(Slowo questionAnswer)
        {
            IEnumerable<Pytanie> questions = await _questionRepository.GetPytaniaOdpowiedz(questionAnswer);
            return View(questions);
        }
        [HttpPost("Question/DodajPytanie")]
        public async Task<IActionResult> DodajPytanie(PytanieVM pytanieVM)
        {
            try
            {
                Pytanie pytanie = new Pytanie
                {
                    Tresc = pytanieVM.Tresc,
                    Trudnosc = pytanieVM.Trudnosc,
                    Odpowiedz = await _wordRepository.GetSlowo(pytanieVM.Odpowiedz)
                };
                _questionRepository.Add(pytanie);
                _questionRepository.Save();
                return RedirectToAction("Question");

            }
            catch (DbUpdateException ex)
            {
                var slowa = _wordRepository.GetSlowa();
                ViewData["Slowa"] = slowa;
                ModelState.AddModelError("", "Wystąpił błąd zapisu do bazy danych: " + ex.Message);
            }
            return View(pytanieVM);
        }
        [HttpGet("Question/DodajPytanie")]
        public async Task<IActionResult> DodajPytanie()
        {
            var slowa = await _wordRepository.GetSlowa();
            var pytanieVM = new PytanieVM
            {
                Slowa = slowa,
                Trudnosc = 0,
                Tresc = "",
                Odpowiedz = 0
            };
            return View(pytanieVM);
        }
        public async Task<IActionResult> Question()
        {
            IEnumerable<Pytanie> questions = await _questionRepository.GetPytania();
            return View(questions);
        }
        [HttpGet("Question/Edytuj/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var slowa = await _wordRepository.GetSlowa();
            var pytanie = await _questionRepository.GetPytanie(id);
            var pytanieVM = new PytanieVM
            {
                ID = id,
                Slowa = slowa,
                Tresc = pytanie.Tresc,
                Trudnosc = pytanie.Trudnosc,
                Odpowiedz = pytanie.Odpowiedz.ID_Slowa
            };
            if (pytanie == null)
            {
                return NotFound();
            }

            return View(pytanieVM);
        }

        [HttpPost("Question/Edytuj/{id}")]
        public async Task<IActionResult> Edit(PytanieVM pytanievm)
        {
            var pytanie = await _questionRepository.GetPytanie(pytanievm.ID);
            pytanie.Tresc = pytanievm.Tresc;
            pytanie.Trudnosc = pytanievm.Trudnosc;
            pytanie.Odpowiedz = await _wordRepository.GetSlowo(pytanievm.Odpowiedz);
            _questionRepository.Update(pytanie);
            return RedirectToAction("Question");
        }
        public async Task<IActionResult> Usun(int id)
        {
            var pytanie = await _questionRepository.GetPytanie(id);

            if (pytanie == null)
            {
                return NotFound(); 
            }

            return View(pytanie);
        }

        [HttpPost("Question/PotwierdzUsuniecie")]
        public IActionResult PotwierdzUsuniecie(Pytanie pytanie)
        {
            var success = _questionRepository.Delete(pytanie.ID_Pytania);

            if (success)
            {
                return RedirectToAction("Question"); // Przekieruj na listę słów lub inną stronę
            }
            else
            {
                return NotFound(); // W razie problemów, np. braku słowa do usunięcia
            }
        }
    }
}
