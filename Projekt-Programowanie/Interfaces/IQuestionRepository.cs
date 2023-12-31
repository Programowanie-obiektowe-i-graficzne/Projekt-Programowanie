﻿using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Interfaces
{
    public interface IQuestionRepository
    {
        public Task<IEnumerable<Pytanie>> GetPytania();
        public Task<Pytanie> GetPytanie(int id);
        public Task<IEnumerable<Pytanie>> GetPytaniaTrudnosc(int trudnosc);
        public Task<IEnumerable<Pytanie>> GetPytaniaOdpowiedz(Slowo odpowiedz);
        bool Add(Pytanie pytanie);
        bool Save();
        bool Delete(int id);
        bool Update(Pytanie pytanie);
    }
}
