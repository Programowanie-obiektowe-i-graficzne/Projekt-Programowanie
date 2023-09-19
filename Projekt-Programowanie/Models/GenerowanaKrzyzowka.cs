namespace Projekt_Programowanie.Models
{
    public class GenerowanaKrzyzowka
    {
        public string[,] Krzyzowka { get; set; }
        public string[,] RozwiazywanaKrzyzowka { get; set; }
        public string Odpowiedz1 { get; set; }
        public string Odpowiedz2 { get; set; }
        public string Odpowiedz3 { get; set; }
        public string Odpowiedz4 { get; set; }
        public string Odpowiedz5 { get; set; }
        public string Odpowiedz6 { get; set; }
        public GenerowanaKrzyzowka()
        {
            Krzyzowka = new string[9, 9];
            RozwiazywanaKrzyzowka = new string[9, 9];
            Odpowiedz1 = "";
            Odpowiedz2 = "";
            Odpowiedz3 = "";
            Odpowiedz4 = "";
            Odpowiedz5 = "";
            Odpowiedz6 = "";
        }
    }
}
