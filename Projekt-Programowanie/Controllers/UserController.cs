using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IActionResult> GetUzytkownicy()
        {
            var uzytkownicy = await _userRepository.GetUzytkownicy();
            return View(uzytkownicy);
        }
        public async Task<IActionResult> GetUzytkownik(int userId)
        {
            var uzytkownik = await _userRepository.GetUzytkownik(userId);
            return View(uzytkownik);
        }
        public async Task<IActionResult> GetUzytkownik(string userName)
        {
            var uzytkownik = await _userRepository.GetUzytkownik(userName);
            return View(uzytkownik);
        }
    }
}
