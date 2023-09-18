using Microsoft.EntityFrameworkCore;
using Projekt_Programowanie.Data;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Uzytkownik> GetUzytkownik(int id)
        {
            return await _context.Uzytkownicy.Where(p => p.ID_Uzytkownik == id).FirstOrDefaultAsync();
        }
        public async Task<Uzytkownik> GetUzytkownik(string name)
        {
            return await _context.Uzytkownicy.Where(p => p.Nazwa == name).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Uzytkownik>> GetUzytkownicy()
        {
            return await _context.Uzytkownicy.OrderBy(p => p.ID_Uzytkownik).ToListAsync();
        }
    }
}
