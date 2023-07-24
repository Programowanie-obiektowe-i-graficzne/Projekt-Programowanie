namespace Projekt_Programowanie.Models.MODELS
{
    public class Slowo
    {
        public int ID_Slowa { get; set; }
        public string NazwaSlowa { get; set; }
        public string Kategoria { get; set; }
        public int Dl_Slowa { get; set; }
        public ICollection<Pytanie> Pytania { get; set; }
    }
}
