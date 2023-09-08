namespace Projekt_Programowanie.Models
{
    public class GenerowanaKrzyzowka
    {
        public string[,] Krzyzowka { get; set; }
        public GenerowanaKrzyzowka()
        {
            Krzyzowka = new string[9, 9];
        }
    }
}
