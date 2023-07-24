namespace Projekt_Programowanie.Models.MODELS
{
    public class Wzor
    {
        public int ID_Wzoru { get; set; }
        public int Rozmiar { get; set; }
        public ICollection<Krzyzowka> Krzyzowki { get; set; } 
    }
}
