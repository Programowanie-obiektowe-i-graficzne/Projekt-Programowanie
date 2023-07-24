namespace Projekt_Programowanie.Models.MODELS
{
    public class TabelaWynikow
    {
        public int ID_Wynikow { get; set; }
        public int Czas { get; set; }
        public int Trudnosc { get; set; }
        public ICollection<Uzytkownik> Uzytkownicy { get; set; }
        public Krzyzowka Krzyzowka { get; set; }
    }
}
