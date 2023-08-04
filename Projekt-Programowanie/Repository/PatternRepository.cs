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
        public ICollection<Wzor> getWzory()
        {
            return _context.Wzory.OrderBy(p => p.ID_Wzoru).ToList();
        }
        public Wzor GetWzor(int id)
        {
            return _context.Wzory.Where(p => p.ID_Wzoru == id).FirstOrDefault();
        }
        ICollection<Wzor> GetWzoryWielkosc(int rozmiar)
        {
            return _context.Wzory.Where(p => p.Rozmiar == rozmiar).ToList();
        }
    }
}
