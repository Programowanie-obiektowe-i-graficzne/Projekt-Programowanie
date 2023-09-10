using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Controllers
{
    public class WordController : Controller
    {
        private readonly IWordRepository _wordRepository;
        public WordController(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }
        public async Task<IActionResult> GetSlowa()
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
    }
}
