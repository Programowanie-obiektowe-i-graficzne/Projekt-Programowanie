using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Interfaces
{
    public interface ICrossRepository
    {
        ICollection<Krzyzowka> getKrzyzowki();
        Krzyzowka GetKrzyzowka(int id);
        bool KrzyzowkaExist(int id);
        ICollection<Krzyzowka> GetKrzyzowkiTrudnosc(int trudnosc);
        ICollection<Krzyzowka> GetKrzyzowkiWzor(Wzor wzor);
    }
}
