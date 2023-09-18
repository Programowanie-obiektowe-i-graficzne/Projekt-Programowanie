using Microsoft.AspNetCore.Mvc;
using Projekt_Programowanie.Models;
using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Interfaces
{
    public interface ICrossRepository
    {
        public Pytanie GetPytanieOdpowiedzTrud(Slowo slowo, int trud);
        public Task<IEnumerable<Krzyzowka>> GetKrzyzowki();
        public Task<Krzyzowka> GetKrzyzowkaById(int id);
        public Task<IEnumerable<Wzor>> GetWzory();
        public Wzor GetWzorById(int id);
        public GenerowanaKrzyzowka generowanie(int wzor);
        bool Generate(Krzyzowka krzyzowka);
        bool Save();
    }
}
