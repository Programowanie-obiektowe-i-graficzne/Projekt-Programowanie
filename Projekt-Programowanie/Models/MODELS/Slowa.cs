namespace Projekt_Programowanie.Models.MODELS
{
    public class Slowa
    {
        public int ID_Slowa { get; set; }
        public string Slowo { get; set; }
        public string Kategoria { get; set; }
        public int Dl_Slowa { get; set; }
        public ICollection<Pytania> Pytania { get; set; }
    }
}
