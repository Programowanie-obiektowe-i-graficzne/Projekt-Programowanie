using Projekt_Programowanie.Data;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Repository
{
    public class TableRepository : ITableRepository
    {
        private readonly DataContext _context;
        public TableRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<TabelaWynikow> getTabelaWynikow()
        {
            return _context.TabeleWynikow.OrderBy(p => p.ID_Wynikow).ToList();
        }

        public TabelaWynikow GetWynik(int id)
        {
            return _context.TabeleWynikow.Where(p => p.ID_Wynikow == id).FirstOrDefault();
        }
        public ICollection<TabelaWynikow> GetWynikiUzytkownik(Uzytkownik uzytkownik)
        {
            return _context.TabeleWynikow.Where(p => p.Uzytkownicy==uzytkownik).ToList();
        }
    }
}

