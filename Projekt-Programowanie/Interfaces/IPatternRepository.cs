using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Interfaces
{
    public interface IPatternRepository
    {
        ICollection<Wzor> getWzory();
        Wzor GetWzor(int id);
        ICollection<Wzor> GetWzoryWielkosc(int rozmiar);
    }
}
