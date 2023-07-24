namespace Projekt_Programowanie.Models.MODELS
{
    public class Pytania
    {
        public int ID_Pytania { get; set; }
        public string Tresc { get; set; }
        public int Trudnosc { get; set; }
        public Slowa Odpowiedz { get; set; }
        public Krzyzowka Krzyzowka { get; set; }
    }
}
