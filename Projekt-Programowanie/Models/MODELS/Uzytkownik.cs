using System.ComponentModel.DataAnnotations;

namespace Projekt_Programowanie.Models.MODELS
{
    public class Uzytkownik
    {
        [Key]
        public int ID_Uzytkownik { get; set; }
        public string Nazwa { get; set; }
        public int Najlepszy_Czas { get; set; }
        public int Ilosc_Rozwiazanych { get; set; }
        public TabelaWynikow TabelaWynikow { get; set; }
    }
}
