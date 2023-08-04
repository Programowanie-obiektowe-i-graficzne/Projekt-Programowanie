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

        public ICollection<TabelaWynikow> getTabela()
        {
            throw new NotImplementedException();
        }

        public ICollection<TabelaWynikow> GetTabelaWynikow()
        {
            return _context.TabeleWynikow.OrderBy(p => p.ID_Wynikow).ToList();
        }
    }
}
