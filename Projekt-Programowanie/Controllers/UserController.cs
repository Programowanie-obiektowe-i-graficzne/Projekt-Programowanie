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
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Uzytkownik>))]
        public IActionResult GetUzytkownicy()
        {
            var uzytkownicy = _userRepository.getUzytkownicy();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(uzytkownicy);
        }
        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(Uzytkownik))]
        [ProducesResponseType(400)]
        public IActionResult GetUzytkownik(int userId)
        {
            var uzytkownik = _userRepository.GetUzytkownik(userId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(uzytkownik);
        }
        [HttpGet("{userName}")]
        [ProducesResponseType(200, Type = typeof(Uzytkownik))]
        [ProducesResponseType(400)]
        public IActionResult GetUzytkownik(string userName)
        {
            var uzytkownik = _userRepository.GetUzytkownik(userName);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(uzytkownik);
        }
    }
}
