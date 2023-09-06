using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Projekt_Programowanie.Data;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models;
using Projekt_Programowanie.Models.MODELS;
using Projekt_Programowanie.Repository;

namespace Projekt_Programowanie.Repository
{
    public class CrossRepository : ICrossRepository
    {
        private readonly DataContext _context;
        public CrossRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Wzor>> GetWzory()
        {
            return await _context.Wzory.OrderBy(p=>p.ID_Wzoru).ToListAsync();
        }

        public Wzor GetWzorById(int id)
        {
            return _context.Wzory.Where(p => p.ID_Wzoru == id).FirstOrDefault();
        }

        public int dlugosc(int dane)
        {
            int dl = dane % 10;
            return dl;
        }

        public int wsp_y(int dane)
        {
            int y = dane % 1000;
            y -= dlugosc(dane);
            y /= 10;
            return y;
        }

        public int wsp_x(int dane)
        {
            int x = dane % 100000;
            x -= dlugosc(dane);
            x-= wsp_y(dane);
            x /= 1000;
            return x;
        }

        public int kierunek(int dane)
        {
            int kier = dane;
            kier -= dlugosc(dane);
            kier -= wsp_x(dane);
            kier-= wsp_y(dane);
            kier /= 100000;
            return kier;
        }

        public GenerowanaKrzyzowka wprowadz(int dane, GenerowanaKrzyzowka tabelka)
        {
            GenerowanaKrzyzowka pomoc = tabelka;
            int dlug = dlugosc(dane);
            int wspX = wsp_x(dane);
            int wspY = wsp_y(dane);
            int kieru = kierunek(dane);
            for (int i = 0; i < dlug; i++)
            {
                if (pomoc.Krzyzowka[wspX,wspY] == ".")
                {
                    pomoc.Krzyzowka[wspX, wspY] = ",";
                }
                else
                {
                    pomoc.Krzyzowka[wspX, wspY] = ".";
                }
                if(kieru == 1)
                {
                    wspX += 1;
                }
                else
                {
                    wspY += 1;
                }
            }

            return pomoc;
        }

        public int znajdzPolaczenie(int dane1, int dane2)
        {
            int polaczenie = 0;
            int dl1 = dlugosc(dane1);
            int dl2 = dlugosc(dane2);
            int x1 = wsp_x(dane1);
            int x2 = wsp_x(dane2);
            int y1 = wsp_y(dane1);
            int y2 = wsp_y(dane2);
            int kier1 = kierunek(dane1);
            int kier2 = kierunek(dane2);
            if(kier1 == kier2)
            {
                return 0;
            }
            int pomoc = 0;
            for (int i = 0; i<dl1; i++)
            {
                for (int j = 0; j < dl2; j++)
                {
                    if(kier2 == 1)
                    {
                        x2 += 1;
                    }
                    else
                    {
                        y2 += 1;
                    }
                    pomoc += 1;
                    if(x1 == x2 && y1 == y2)
                    {
                        polaczenie = pomoc;
                        break;
                    }
                }
                if(polaczenie == pomoc)
                {
                    break;
                }
                if(kier1 == 1)
                {
                    x1 += 1;
                }
                else
                {
                    y1 += 1;
                }

                pomoc += 10;
            }

            return polaczenie;
        }

        public GenerowanaKrzyzowka generowanie(int wzor)
        {
            Wzor jaki = GetWzorById(wzor);
            int rozmiar = jaki.Rozmiar;
            int slowo1 = jaki.Slowo1;
            int slowo2 = jaki.Slowo2;
            int slowo3 = jaki.Slowo3;
            int slowo4 = jaki.Slowo5;
            int slowo5 = jaki.Slowo5;
            int slowo6 = jaki.Slowo6;

            GenerowanaKrzyzowka tab = new GenerowanaKrzyzowka();
            tab.Krzyzowka = new string[rozmiar, rozmiar];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j< 8; j++)
                {
                    tab.Krzyzowka[i, j] = "?";
                }
            }

            tab = wprowadz(slowo1, tab);
            tab = wprowadz(slowo2, tab);
            tab = wprowadz(slowo3, tab);
            tab = wprowadz(slowo4, tab);
            tab = wprowadz(slowo5, tab);
            tab = wprowadz(slowo6, tab);
            IEnumerable<Slowo> list = GetSlowoDlugosc(dlugosc(slowo1));
            

            
            return tab;
        }

        public IEnumerable<Slowo> GetSlowoDlugosc(int dlugosc)
        {
            return _context.Slowa.Where(p => p.Dl_Slowa == dlugosc).ToList();
        }
        public async Task<IEnumerable<Krzyzowka>> GetKrzyzowki()
        {
            return await _context.Krzyzowki.OrderBy(p => p.ID_Krzyzowki).ToListAsync();
        }
        public async Task<Krzyzowka> GetKrzyzowkaById(int id)
        {
            return await _context.Krzyzowki.FirstOrDefaultAsync(p => p.ID_Krzyzowki==id);
        }
        public bool Generate(Krzyzowka krzyzowka)
        {
            _context.Add(krzyzowka);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
