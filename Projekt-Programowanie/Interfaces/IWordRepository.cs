using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Interfaces
{
    public interface IWordRepository
    {
        ICollection<Slowo> getSlowa();
        Slowo GetSlowo(int dlugosc);
    }
}
