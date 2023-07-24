namespace Projekt_Programowanie.Models.MODELS
{
    public class Krzyzowka
    {
        public int ID_Krzyzowki { get; set; }
        public int Trudnosc { get; set; }
        public ICollection<TabelaWynikow> Wyniki { get; set; }
        public ICollection<Pytania> Pytanie_1 { get; set; }
        public ICollection<Pytania> Pytanie_2 { get; set; }
        public ICollection<Pytania> Pytanie_3 { get; set; }
        public ICollection<Pytania> Pytanie_4 { get; set; }
        public ICollection<Pytania> Pytanie_5 { get; set; }
        public ICollection<Pytania> Pytanie_6 { get; set; }
        public Wzor Wzor { get; set; }
    }
}
