namespace Projekt_Programowanie.Models.MODELS
{
    public class Pytanie
    {
        public int ID_Pytania { get; set; }
        public string Tresc { get; set; }
        public int Trudnosc { get; set; }
        public Slowo Odpowiedz { get; set; }
        public Krzyzowka Krzyzowka { get; set; }
    }
}
