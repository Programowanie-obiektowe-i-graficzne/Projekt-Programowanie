using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.MODELS;
using Projekt_Programowanie.Repository;

namespace Projekt_Programowanie.Controllers
{
    public class PatternController : Controller
    {
        private readonly IPatternRepository _patternRepository;

        public PatternController(IPatternRepository patternRepository)
        {
            _patternRepository = patternRepository;
        }
        public async Task<IActionResult> GetWzory()
        {
            var wzory = await _patternRepository.GetWzory();
            return Ok(wzory);
        }
        public async Task<IActionResult> GetWzoryWielkosc(int patternSize)
        {
            var wzory = await _patternRepository.GetWzoryWielkosc(patternSize);
            return Ok(wzory);
        }
    }
}
