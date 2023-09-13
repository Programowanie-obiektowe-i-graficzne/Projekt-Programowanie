using Microsoft.EntityFrameworkCore;
using Projekt_Programowanie.Data;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DataContext _context;
        public QuestionRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Pytanie>> GetPytania()
        {
            return await _context.Pytania.OrderBy(p => p.ID_Pytania).ToListAsync();
        }

        public async Task<Pytanie> GetPytanie(int id)
        {
            return await _context.Pytania.Where(p => p.ID_Pytania == id).FirstOrDefaultAsync();
        }

        public async Task<Pytanie> GetPytanie(string pytanie)
        {
            return await _context.Pytania.Where(p => p.Tresc == pytanie).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Pytanie>> GetPytaniaTrudnosc(int trudnosc)
        {
            return await _context.Pytania.Where(p => p.Trudnosc == trudnosc).ToListAsync();
        }

        public async Task<IEnumerable<Pytanie>> GetPytaniaOdpowiedz(Slowo odpowiedz)
        {
            return await _context.Pytania.Where(p => p.Odpowiedz == odpowiedz).ToListAsync();
        }

        public bool Add(Pytanie pytanie)
        {
            _context.Pytania.Add(pytanie);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Delete(Pytanie pytanie)
        {
            _context.Remove(pytanie);
            return Save();
        }

        public bool Update(Pytanie pytanie)
        {
            _context.Update(pytanie);
            return Save();
        }
    }
}
