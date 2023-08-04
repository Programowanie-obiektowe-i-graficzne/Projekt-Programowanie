using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Interfaces
{
    public interface ICrossRepository
    {
        ICollection<Krzyzowka> getKrzyzowki();
        Krzyzowka GetKrzyzowka(int id);
        ICollection<Krzyzowka> getKrzyzowkiTrudnosc(int trudnosc);
        ICollection<Krzyzowka> getKrzyzowkiWzor(Wzor wzor);
    }
}
