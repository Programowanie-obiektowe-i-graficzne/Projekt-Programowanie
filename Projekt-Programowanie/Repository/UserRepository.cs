﻿using Projekt_Programowanie.Data;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public Uzytkownik GetUser(int id)
        {
            return _context.Uzytkownicy.Where(p => p.ID_Uzytkownik == id).FirstOrDefault();
        }
        public Uzytkownik GetUser(string name)
        {
            return _context.Uzytkownicy.Where(p => p.Nazwa == name).FirstOrDefault();
        }
        public ICollection<Uzytkownik> getUsers()
        {
            return _context.Uzytkownicy.OrderBy(p => p.ID_Uzytkownik).ToList();
        }
    }
}