using System.ComponentModel.DataAnnotations;

namespace Projekt_Programowanie.Models.MODELS
{
    public class Krzyzowka
    {
        [Key]
        public int ID_Krzyzowki { get; set; }
        public int Trudnosc { get; set; }
        public ICollection<TabelaWynikow> Wyniki { get; set; }
        public int Pyt1ID { get; set; }
        public Pytanie Pytanie_1 { get; set; }
        public int Pyt2ID { get; set; }
        public Pytanie Pytanie_2 { get; set; }
        public int Pyt3ID { get; set; }
        public Pytanie Pytanie_3 { get; set; }
        public int Pyt4ID { get; set; }
        public Pytanie Pytanie_4 { get; set; }
        public int Pyt5ID { get; set; }
        public Pytanie Pytanie_5 { get; set; }
        public int Pyt6ID { get; set; }
        public Pytanie Pytanie_6 { get; set; }
        public Wzor Wzor { get; set; }
    }
}
