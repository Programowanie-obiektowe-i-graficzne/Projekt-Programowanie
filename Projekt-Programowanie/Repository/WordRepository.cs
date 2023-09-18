using Microsoft.EntityFrameworkCore;
using Projekt_Programowanie.Data;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Repository
{
    public class WordRepository : IWordRepository
    {
        private readonly DataContext _context;
        public WordRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Slowo> GetSlowoNaz(string nazwa)
        {
            return await _context.Slowa.Where(p => p.NazwaSlowa == nazwa).FirstOrDefaultAsync();
        }
        public async Task<Slowo> GetSlowoDl(int dlugosc, int skok)
        {
            return await _context.Slowa.Where(p => p.Dl_Slowa == dlugosc).Skip(skok).FirstOrDefaultAsync();
        }

        public async Task<Slowo> zwrocKolejne(IEnumerable<Slowo> collenction, int dlugosc)
        {
            return await GetSlowo(5);
        }

        public IEnumerable<Slowo> GetSlowa()
        {
            return _context.Slowa.OrderBy(p => p.ID_Slowa).ToList();
        }

        public async Task<Slowo> GetSlowo(int id)
        {
            return await _context.Slowa.Where(p => p.ID_Slowa == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Slowo>> GetSlowoDlugosc(int dlugosc)
        {
            return await _context.Slowa.Where(p => p.Dl_Slowa == dlugosc).ToListAsync();
        }

        public bool Add(Slowo slowo)
        {
            slowo.NazwaSlowa = slowo.NazwaSlowa.ToLower();
            _context.Slowa.Add(slowo);
            return Save();
        }

        public bool Delete(int id)
        {
            var slowoToDelete = _context.Slowa.Find(id);
            _context.Slowa.Remove(slowoToDelete); // Usuń słowo
            return Save();
        }

        public bool Update(Slowo slowo)
        {
            _context.Slowa.Update(slowo);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
