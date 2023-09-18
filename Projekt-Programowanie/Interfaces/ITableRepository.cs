using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Interfaces
{
    public interface ITableRepository
    {
        public Task<IEnumerable<TabelaWynikow>> GetTabelaWynikow();
        public Task<TabelaWynikow> GetWynik(int id);
        Task<IEnumerable<TabelaWynikow>> GetWynikiUzytkownik(Uzytkownik uzytkownik);
    }
}
