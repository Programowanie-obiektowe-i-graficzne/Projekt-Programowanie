﻿using Projekt_Programowanie.Data;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Repository
{
    public class WordRepository : IWordRepository
    {
        private readonly DataContext _context;
        public WordRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Slowo> getSlowa()
        {
            return _context.Slowa.OrderBy(p => p.ID_Slowa).ToList();
        }
        public Slowo GetSlowo(int id)
        {
            return _context.Slowa.Where(p => p.ID_Slowa == id).FirstOrDefault();
        }
        public ICollection<Slowo> GetSlowoDlugosc(int dlugosc)
        {
            return _context.Slowa.Where(p => p.Dl_Slowa==dlugosc).ToList();
        }

        public Slowo GetSlowoDl(int dlugosc, int skok)
        {
            return _context.Slowa.Where(p => p.Dl_Slowa == dlugosc).Skip(skok).FirstOrDefault();
        }

        public Slowo zwrocKolejne(ICollection<Slowo> collenction, int dlugosc)
        {
            return GetSlowo(5);
        }
    }
}
