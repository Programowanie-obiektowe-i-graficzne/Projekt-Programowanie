using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Interfaces
{
    public interface IWordRepository
    {
        public Task<IEnumerable<Slowo>> GetSlowa();
        public Task<Slowo> GetSlowo(int id);
        public Task<IEnumerable<Slowo>> GetSlowoDlugosc(int dlugosc);
        public Task<Slowo> zwrocKolejne(IEnumerable<Slowo> collenction, int dlugosc);
        public Task<Slowo> GetSlowoDl(int dlugosc, int skok);
        public Task<Slowo> GetSlowoNaz(string nazwa);
        bool Add(Slowo slowo);
        bool Delete(Slowo slowo);
        bool Update(Slowo slowo);
        bool Save();
    }
}
