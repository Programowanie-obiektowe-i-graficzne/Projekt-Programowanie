using System.ComponentModel.DataAnnotations;
namespace Projekt_Programowanie.Models.MODELS
{
    public class Wzor
    {
        [Key]
        public int ID_Wzoru { get; set; }
        public int Rozmiar { get; set; }
        public int Slowo1 { get; set; }
        public int Slowo2 { get; set; }
        public int Slowo3 { get; set; }
        public int Slowo4 { get; set; }
        public int Slowo5 { get; set; }
        public int Slowo6 { get; set; }
        public ICollection<Krzyzowka> Krzyzowki { get; set; } 
    }
}
