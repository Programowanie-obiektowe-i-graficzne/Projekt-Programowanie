using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Interfaces
{
    public interface IUserRepository
    {
        ICollection<Uzytkownik> getUzytkownicy();
        Uzytkownik GetUzytkownik(int id);
        Uzytkownik GetUzytkownik(string username);

    }
}
