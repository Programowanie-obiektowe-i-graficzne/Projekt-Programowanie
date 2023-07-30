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
        public ICollection<Slowo> GetSlowa()
        {
            return _context.Slowa.OrderBy(p => p.ID_Slowa).ToList();
        }

        public ICollection<Slowo> getSlowa()
        {
            throw new NotImplementedException();
        }

        public Slowo GetSlowoDl(int dlugosc)
        {
            var a = new Random();
            int ile = _context.Slowa.Where(p => p.Dl_Slowa == dlugosc).Count();
            return _context.Slowa.Where(p => p.Dl_Slowa == dlugosc).Skip(a.Next(ile)).FirstOrDefault();
        }
        public Slowo GetSlowo(int id)
        {
            return _context.Slowa.Where(p => p.ID_Slowa == id).FirstOrDefault();
        }

        public ICollection<Slowo> GetSlowa(string kategoria)
        {
            return _context.Slowa.Where(p => p.Kategoria == kategoria).ToList();
        }
    }
}
