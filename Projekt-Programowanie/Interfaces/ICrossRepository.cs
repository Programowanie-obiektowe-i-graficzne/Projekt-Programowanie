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
        public Task<GenerowanaKrzyzowka> generowanieDoRozw(GenerowanaKrzyzowka gener, int wzor);
        public Task<Slowo> GetSlowoNaz(string nazwa);
        bool Generate(Krzyzowka krzyzowka);
        bool Save();
    }
}
