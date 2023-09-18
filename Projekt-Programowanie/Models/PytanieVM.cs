using Projekt_Programowanie.Models.MODELS;

public class PytanieVM
{
    public IEnumerable<Slowo> Slowa { get; set; }
    public int ID { get; set; }
    public string Tresc { get; set; }
    public int Trudnosc { get; set; }
    public int Odpowiedz { get; set; }
}