using System.ComponentModel.DataAnnotations;

namespace Projekt_Programowanie.Models.MODELS
{
    public class Pytanie
    {
        [Key]
        public int ID_Pytania { get; set; }
        public string Tresc { get; set; }
        public int Trudnosc { get; set; }
        public int Odpowiedz { get; set; }
    }
}
