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
        private readonly DataContext _context;
        public QuestionController(IQuestionRepository questionRepository, DataContext context)
        {
            _questionRepository = questionRepository;
            _context = context;
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
        public IActionResult DodajPytanie(Pytanie pytanie)
        {
            var slowa = _context.Slowa.ToList();
            ViewData["Slowa"] = slowa;
            try
            {
                _questionRepository.Add(pytanie);
                _questionRepository.Save();
                return RedirectToAction("Question");
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Wystąpił błąd zapisu do bazy danych: " + ex.Message);
            }
            return View(pytanie);
        }
        [HttpGet("Question/DodajPytanie")]
        public IActionResult DodajPytanie()
        {
            var slowa = _context.Slowa.ToList();
            ViewData["Slowa"] = slowa;

            return View();
        }
        public async Task<IActionResult> Question()
        {
            IEnumerable<Pytanie> questions = await _questionRepository.GetPytania();
            return View(questions);
        }
    }
}
