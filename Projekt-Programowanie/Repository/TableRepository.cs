using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<TabelaWynikow>> GetTabelaWynikow()
        {
            return await _context.TabeleWynikow.OrderBy(p => p.ID_Wynikow).ToListAsync();
        }

        public async Task<TabelaWynikow> GetWynik(int id)
        {
            return await _context.TabeleWynikow.Where(p => p.ID_Wynikow == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<TabelaWynikow>> GetWynikiUzytkownik(Uzytkownik uzytkownik)
        {
            return await _context.TabeleWynikow.Where(p => p.Uzytkownicy==uzytkownik).ToListAsync();
        }
    }
}

