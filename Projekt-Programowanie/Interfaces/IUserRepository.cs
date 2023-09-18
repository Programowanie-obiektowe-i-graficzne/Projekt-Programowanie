using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<Uzytkownik>> GetUzytkownicy();
        public Task<Uzytkownik> GetUzytkownik(int id);
        public Task<Uzytkownik> GetUzytkownik(string username);

    }
}
