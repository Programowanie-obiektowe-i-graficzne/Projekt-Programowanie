using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Interfaces
{
    public interface IPatternRepository
    {
        public Task<IEnumerable<Wzor>> GetWzory();
        public Task<Wzor> GetWzor(int id);
        public Task<IEnumerable<Wzor>> GetWzoryWielkosc(int rozmiar);
    }
}
