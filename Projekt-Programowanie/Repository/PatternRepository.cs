using Microsoft.EntityFrameworkCore;
using Projekt_Programowanie.Data;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Repository
{
    public class PatternRepository : IPatternRepository
    {
        private readonly DataContext _context;
        public PatternRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Wzor>> GetWzory()
        {
            return await _context.Wzory.OrderBy(p => p.ID_Wzoru).ToListAsync();
        }
        public async Task<Wzor> GetWzor(int id)
        {
            return await _context.Wzory.Where(p => p.ID_Wzoru == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Wzor>> GetWzoryWielkosc(int rozmiar)
        {
            return await _context.Wzory.Where(p => p.Rozmiar == rozmiar).ToListAsync();
        }
    }
}
