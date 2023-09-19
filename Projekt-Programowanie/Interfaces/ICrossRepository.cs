using Microsoft.AspNetCore.Mvc;
using Projekt_Programowanie.Models;
using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Interfaces
{
    public interface ICrossRepository
    {
        public Task<Pytanie> GetPytanieOdpowiedzTrud(Slowo slowo, int trud);
        public Task<IEnumerable<Krzyzowka>> GetKrzyzowki();
        public Task<Krzyzowka> GetKrzyzowkaById(int id);
        public Task<IEnumerable<Wzor>> GetWzory();
        public Task<Wzor> GetWzorById(int id);
        public Task<GenerowanaKrzyzowka> generowanie(int wzor);
        public string[,] generowanieDoRozw(string[,] gener, Wzor jaki);
        public Task<Slowo> GetSlowoNaz(string nazwa);
        public GenerowanaKrzyzowka wprowadzenieSlowa(string slow, GenerowanaKrzyzowka tab, int slowoX);
        public bool sprawdzanie(GenerowanaKrzyzowka tab);
        bool Generate(Krzyzowka krzyzowka);
        bool Save();
    }
}
