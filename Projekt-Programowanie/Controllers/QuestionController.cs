using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.MODELS;
using System.Collections.Generic;

namespace Projekt_Programowanie.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public async Task<IActionResult> GetPytania()
        {
            IEnumerable<Pytanie> questions = await _questionRepository.GetPytania();
            return View(questions);
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
        public async Task<IActionResult> DodajPytanie(Slowo question)
        {
            return View();
        }
    }
}
