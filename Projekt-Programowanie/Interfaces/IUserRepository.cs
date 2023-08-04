using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Interfaces
{
    public interface IUserRepository
    {
        ICollection<Uzytkownik> GetUsers();
        Uzytkownik GetUser(int id);
        Uzytkownik GetUser(string username);

    }
}
