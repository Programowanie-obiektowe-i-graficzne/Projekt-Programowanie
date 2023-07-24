using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Data
{
    public class DataContext : DbContext
    {
        public string DbPath { get; }
        public DataContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "krzyzowki.db");
        }
        public DbSet<Krzyzowka> Krzyzowki { get; set; }
        public DbSet<Pytanie> Pytania { get; set; }
        public DbSet<Slowo> Slowa { get; set; }
        public DbSet<TabelaWynikow> TabeleWynikow { get; set; } 
        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<Wzor> Wzory { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
}
