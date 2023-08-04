﻿using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Interfaces
{
    public interface IQuestionRepository
    {
        ICollection<Pytanie> getPytania();
        Pytanie GetPytanie(int id);
        Pytanie GetPytanie(string pytanie);
        ICollection<Pytanie> getPytanieTrudnosc(int trudnosc);
        ICollection<Pytanie> getPytanieOdpowiedz(Slowo odpowiedz);
    }
}
