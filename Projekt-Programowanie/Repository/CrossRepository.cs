using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public async Task<Wzor> GetWzorById(int id)
        {
            return await _context.Wzory.Where(p => p.ID_Wzoru == id).FirstOrDefaultAsync();
        }

        public async Task<Pytanie> GetPytanieOdpowiedzTrud(Slowo slowo, int trud)
        {
            return await _context.Pytania.Where(p => p.Odpowiedz == slowo && p.Trudnosc == trud).FirstOrDefaultAsync();
        }

        public async Task<Slowo> GetSlowoNaz(string nazwa)
        {
            return await _context.Slowa.Where(p => p.NazwaSlowa == nazwa).FirstOrDefaultAsync();
        }
        public int dlugosc(int dane)
        {
            int dl = dane % 10;
            return dl;
        }

        public int wsp_col(int dane)
        {
            int y = dane % 1000;
            y /= 10;
            return y;
        }

        public int wsp_line(int dane)
        {
            int x = dane % 100000;
            x /= 1000;
            return x;
        }

        public int kierunek(int dane)
        {
            int kier = dane;
            kier /= 100000;
            return kier;
        }

        public GenerowanaKrzyzowka wprowadz(int dane, GenerowanaKrzyzowka tabelka)
        {
            GenerowanaKrzyzowka pomoc = tabelka;
            int dlug = dlugosc(dane);
            int wspY = wsp_line(dane);
            int wspX = wsp_col(dane);
            int kieru = kierunek(dane);
            for (int i = 0; i < dlug; i++)
            {
                if (pomoc.Krzyzowka[wspY,wspX] == ".")
                {
                    pomoc.Krzyzowka[wspY, wspX] = ",";
                }
                else
                {
                    pomoc.Krzyzowka[wspY, wspX] = ".";
                }
                if(kieru == 1)//prawo
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
        public string[,] wprowadz(int dane, string[,] tabelka, string slowo, string pytanie)
        {
            string[,] pomoc = tabelka;
            int dlug = dlugosc(dane);
            int wspY = wsp_line(dane);
            int wspX = wsp_col(dane);
            int kieru = kierunek(dane);
            int pom = 0;
            pomoc[wspY, wspX] = pytanie;
            if (kieru == 1) //prawo
            {
                wspY += 1;
            }
            else
            {
                wspX += 1;
            }
            for (int i = 1; i < dlug; i++)
            {
                pomoc[wspY, wspX] = slowo[pom].ToString();
                pom += 1;
                if (kieru == 2)
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
            int y1 = wsp_line(dane1);
            int y2 = wsp_line(dane2);
            int x1 = wsp_col(dane1);
            int x2 = wsp_col(dane2);
            int kier1 = kierunek(dane1);
            int kier2 = kierunek(dane2);
            if(kier1 == kier2)
            {
                return 0;
            }
            int pomoc = 0;
            for (int i = 0; i < dl1; i++)
            {
                for (int j = 0; j < dl2; j++)
                {
                    if(kier2 == 2)
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
                if(kier1 == 2)
                {
                    x1 += 1;
                }
                else
                {
                    y1 += 1;
                }
                pomoc -= (pomoc % 10);
                pomoc += 10;
                x2 = wsp_col(dane2);
                y2 = wsp_line(dane2);
            }

            return polaczenie;
        }

        public string[,] wprowadzPuste(int gdzie, string[,] tab)
        {
            string[,] pomoc = tab;
            int dlug = dlugosc(gdzie);
            int wspY = wsp_line(gdzie);
            int wspX = wsp_col(gdzie);
            int kieru = kierunek(gdzie);
            if (kieru == 1)
            {
                wspY += 1;
            }
            else
            {
                wspX += 1;
            }
            for (int i = 1; i < dlug; i++)
            {
                pomoc[wspY, wspX] = "";
                if (kieru == 2)
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

        public string[,] generowanieDoRozw(string[,] gener, Wzor jaki)
        {
            string[,] tab = gener;
            tab = wprowadzPuste(jaki.Slowo1, tab);
            tab = wprowadzPuste(jaki.Slowo2, tab);
            tab = wprowadzPuste(jaki.Slowo3, tab);
            tab = wprowadzPuste(jaki.Slowo4, tab);
            tab = wprowadzPuste(jaki.Slowo5, tab);
            tab = wprowadzPuste(jaki.Slowo6, tab);
            return tab;
        }
        public async Task<GenerowanaKrzyzowka> generowanieDoRozw1(GenerowanaKrzyzowka gener, int wzor)
        {
            Wzor jaki = await GetWzorById(wzor);
            GenerowanaKrzyzowka tab = new GenerowanaKrzyzowka();
            tab.Krzyzowka = gener.Krzyzowka;
            tab.RozwiazywanaKrzyzowka = gener.Krzyzowka;
            tab = wprowadzenieSlowa(gener.Odpowiedz1, tab, jaki.Slowo1);
            tab = wprowadzenieSlowa(gener.Odpowiedz2, tab, jaki.Slowo2);
            tab = wprowadzenieSlowa(gener.Odpowiedz3, tab, jaki.Slowo3);
            tab = wprowadzenieSlowa(gener.Odpowiedz4, tab, jaki.Slowo4);
            tab = wprowadzenieSlowa(gener.Odpowiedz5, tab, jaki.Slowo5);
            tab = wprowadzenieSlowa(gener.Odpowiedz6, tab, jaki.Slowo6);
            return tab;
        }

        public async Task<GenerowanaKrzyzowka> generowanie(int wzor)
        {
            Wzor jaki = await GetWzorById(wzor);
            int rozmiar = jaki.Rozmiar;
            int slowo1 = jaki.Slowo1;
            int slowo2 = jaki.Slowo2;
            int slowo3 = jaki.Slowo3;
            int slowo4 = jaki.Slowo4;
            int slowo5 = jaki.Slowo5;
            int slowo6 = jaki.Slowo6;

            GenerowanaKrzyzowka tab = new GenerowanaKrzyzowka();
            tab.Krzyzowka = new string[rozmiar, rozmiar];
            for (int i = 0; i < jaki.Rozmiar; i++)
            {
                for (int j = 0; j < jaki.Rozmiar; j++)
                {
                    tab.Krzyzowka[i, j] = "?";
                }
            }

            IEnumerable<Slowo> list1 = GetSlowoDlugosc(dlugosc(slowo1) -1);
            IEnumerable<Slowo> list2 = GetSlowoDlugosc(dlugosc(slowo2) -1);
            IEnumerable<Slowo> list3 = GetSlowoDlugosc(dlugosc(slowo3) -1);
            IEnumerable<Slowo> list4 = GetSlowoDlugosc(dlugosc(slowo4) -1);
            IEnumerable<Slowo> list5 = GetSlowoDlugosc(dlugosc(slowo5) -1);
            IEnumerable<Slowo> list6 = GetSlowoDlugosc(dlugosc(slowo6) -1);

            Random ran = new Random();
            int r1 = ran.Next();
            int r2 = ran.Next();
            int r3 = ran.Next();
            string ss1 = "aaaaaa", ss2 = "aaaaaa", ss3 = "aaaaaa", ss4 = "aaaaaa", ss5 = "aaaaaa", ss6 = "aaaaaa";
            bool czy = false;
            for (int i = 0; i < list1.Count(); i++) //szukanie slowa 1
            {
                ss1 = znajdzSlowo(list1, 0, 0, 0, 0, 0, "", "", "", "", "", (r1 + i) % list1.Count());
                if (ss1 == "Nic")
                    continue;
                for (int j = 0; j < list2.Count(); j++) //szukanie slowa 2
                {
                    ss2 = znajdzSlowo(list2, znajdzPolaczenie(slowo1, slowo2), 0, 0, 0, 0, ss1, "", "", "", "", (r2 + j) % list2.Count());
                    if (ss2 == "Nic" || ss2 == ss1)
                        continue;
                    for (int q = 0; q < list3.Count(); q++) //szukanie slowa 3
                    {
                        ss3 = znajdzSlowo(list3, znajdzPolaczenie(slowo1, slowo3), znajdzPolaczenie(slowo2, slowo3), 0, 0, 0, ss1, ss2, "", "", "", (r3 + q) % list3.Count());
                        if (ss3 == "Nic" || ss3 == ss1 || ss3 == ss2)
                            continue;
                        for (int w = 0; w < list4.Count(); w++) //szukanie slowa 4
                        {
                            ss4 = znajdzSlowo(list4, znajdzPolaczenie(slowo1, slowo4), znajdzPolaczenie(slowo2, slowo4), znajdzPolaczenie(slowo3, slowo4), 0, 0, ss1, ss2, ss3, "", "", (r1 + w) % list4.Count());
                            if (ss4 == "Nic" || ss4 == ss1 || ss4 == ss2 || ss4 == ss3)
                                continue;
                            for (int e = 0; e < list5.Count(); e++) //szukanie slowa 5
                            {
                                ss5 = znajdzSlowo(list5, znajdzPolaczenie(slowo1, slowo5), znajdzPolaczenie(slowo2, slowo5), znajdzPolaczenie(slowo3, slowo5), znajdzPolaczenie(slowo4, slowo5), 0, ss1, ss2, ss3, ss4, "", (r2 + e) % list5.Count());
                                if (ss5 == "Nic" || ss5 == ss1 || ss5 == ss2 || ss5 == ss3 || ss5 == ss4)
                                    continue;
                                for (int r = 0; r < list6.Count(); r++) //szukanie slowa 6
                                {
                                    ss6 = znajdzSlowo(list6, znajdzPolaczenie(slowo1, slowo6), znajdzPolaczenie(slowo2, slowo6), znajdzPolaczenie(slowo3, slowo6), znajdzPolaczenie(slowo4, slowo6), znajdzPolaczenie(slowo5, slowo6), ss1, ss2, ss3, ss4, ss5, (r3 + r) % list6.Count());
                                    if (ss6 == "Nic" || ss6 == ss1 || ss6 == ss2 || ss6 == ss3 || ss6 == ss4 || ss6 == ss5)
                                        continue;
                                    else
                                        czy = true;
                                    if (czy)
                                        break;
                                }
                                if (czy)
                                    break;
                            }
                            if (czy)
                                break;
                        }
                        if (czy)
                            break;
                    }
                    if (czy)
                        break;
                }
                if (czy)
                    break;
            }

            Slowo s1 = await GetSlowoNaz(ss1);
            Slowo s2 = await GetSlowoNaz(ss2);
            Slowo s3 = await GetSlowoNaz(ss3);
            Slowo s4 = await GetSlowoNaz(ss4);
            Slowo s5 = await GetSlowoNaz(ss5);
            Slowo s6 = await GetSlowoNaz(ss6);

            Pytanie p1 = null;
            Pytanie p2 = null;
            Pytanie p3 = null;
            Pytanie p4 = null;
            Pytanie p5 = null;
            Pytanie p6 = null;

            r1 = (r1 % 3);
            for (int i = 0; i < 5; i++)
            {
                if (p1 == null)
                    p1 = await GetPytanieOdpowiedzTrud(s1, (r1 + i) % 4);
                if (p2 == null)
                    p2 = await GetPytanieOdpowiedzTrud(s2, (r1 + i + 1) % 4);
                if (p3 == null)
                    p3 = await GetPytanieOdpowiedzTrud(s3, (r1 + i + 2) % 4);
                if (p4 == null)
                    p4 = await GetPytanieOdpowiedzTrud(s4, (r1 + 1 + i) % 4);
                if (p5 == null)
                    p5 = await GetPytanieOdpowiedzTrud(s5, (r1 + i) % 4);
                if (p6 == null)
                    p6 = await GetPytanieOdpowiedzTrud(s6, (r1 + 2 + i) % 4);
            }
            tab.Krzyzowka = wprowadz(slowo1, tab.Krzyzowka, ss1, "1. "+p1.Tresc);
            tab.Krzyzowka = wprowadz(slowo2, tab.Krzyzowka, ss2, "2. "+p2.Tresc);
            tab.Krzyzowka = wprowadz(slowo3, tab.Krzyzowka, ss3, "3. "+p3.Tresc);
            tab.Krzyzowka = wprowadz(slowo4, tab.Krzyzowka, ss4, "4. "+p4.Tresc);
            tab.Krzyzowka = wprowadz(slowo5, tab.Krzyzowka, ss5, "5. "+p5.Tresc);
            tab.Krzyzowka = wprowadz(slowo6, tab.Krzyzowka, ss6, "6. "+p6.Tresc);
            tab.RozwiazywanaKrzyzowka = generowanieDoRozw(tab.Krzyzowka, jaki);
            return tab;
        }

        /*public bool sprawdzanie(string[,] uzytkownika, string[,] odpo)
        {
            for (int i = 0; i < uzytkownika.Krzyzowka.Length; i++)
            {
                for (int j = 0; j < uzytkownika.Krzyzowka.Length; j++)
                {
                    if (uzytkownika.Krzyzowka[i, j] != odpo.Krzyzowka[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }*/

        public string[,] wprowadzenieSlowa(string slow, string[,] tab, int slowoX)
        {
            string s = slow;
            int kier = kierunek(slowoX);
            int wspX = wsp_col(slowoX);
            int wspY = wsp_line(slowoX);
            int dlug = dlugosc(slowoX);
            for (int i = 0; i < dlug; i++)
            {
                if (kier == 1)
                {
                    wspX += 1;
                }
                else
                    wspY += 1;
                tab[wspY, wspX] = slow[i].ToString();
            }
            return tab;
        }
        public String znajdzSlowo(IEnumerable<Slowo> lista, int polocz1, int polocz2, int polocz3, int polocz4, int polocz5, String slow1, String slow2, String slow3, String slow4, String slow5, int ziarno)
        {
            Slowo slow;
            int ile = lista.Count();
            if(polocz1 == 0)
            {
                if(polocz2 == 0) 
                {
                    if(polocz3 == 0)
                    {
                        if(polocz4 == 0)
                        {
                            if(polocz5 == 0) //nic
                            {
                                slow = lista.Skip(ziarno).FirstOrDefault();
                            }
                            else //5
                            {
                                slow = lista.Where(p => p.NazwaSlowa[(polocz5%10) - 1] == slow5[(polocz5/10)-1]).Skip(ziarno).FirstOrDefault();
                            }
                        }
                        else //4 tak
                        {
                            if(polocz5 == 0)
                            {
                                slow = lista.Where(p => p.NazwaSlowa[(polocz4 % 10) - 1] == slow4[(polocz4 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                            }
                            else //4 i 5
                            {
                                slow = lista.Where(p => p.NazwaSlowa[(polocz5 % 10) - 1] == slow5[(polocz5 / 10) - 1] && p.NazwaSlowa[(polocz4 % 10) - 1] == slow4[(polocz4 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                            }
                        }
                    }
                    else //3 tak
                    { 
                        if(polocz4 == 0)
                        {
                            if(polocz5 == 0) //same 3
                            {
                                slow = lista.Where(p => p.NazwaSlowa[(polocz3 % 10) - 1] == slow3[(polocz3 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                            }
                            else //3 i 5
                            {
                                slow = lista.Where(p => p.NazwaSlowa[(polocz3 % 10) - 1] == slow3[(polocz3 / 10) - 1] && p.NazwaSlowa[(polocz5 % 10) - 1] == slow5[(polocz5 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                            }
                        }
                        else
                        {
                            if(polocz5 == 0) //3 i 4
                            {
                                slow = lista.Where(p => p.NazwaSlowa[(polocz3 % 10) - 1] == slow3[(polocz3 / 10) - 1] && p.NazwaSlowa[(polocz4 % 10) - 1] == slow4[(polocz4 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                            }
                            else //3, 4 i 5
                            {
                                slow = lista.Where(p => p.NazwaSlowa[(polocz3 % 10) - 1] == slow3[(polocz3 / 10) - 1] && p.NazwaSlowa[(polocz4 % 10) - 1] == slow4[(polocz4 / 10) - 1] && p.NazwaSlowa[(polocz5 % 10) - 1] == slow5[(polocz5 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                            }
                        }
                    }
                }
                else //2 tak
                {
                    if(polocz3 == 0) //2
                    {
                        if(polocz4 == 0)
                        {
                            if(polocz5 == 0) //nadal same 2
                            {
                                slow = lista.Where(p => p.NazwaSlowa[(polocz2 % 10) - 1] == slow2[(polocz2 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                            }
                            else // 2 i 5
                            {
                                slow = lista.Where(p => p.NazwaSlowa[(polocz2 % 10) - 1] == slow2[(polocz2 / 10) - 1] && p.NazwaSlowa[(polocz5 % 10) - 1] == slow5[(polocz5 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                            }
                        }
                        else //2 i 4
                        {
                            if(polocz5 == 0)
                            {
                                slow = lista.Where(p => p.NazwaSlowa[(polocz2 % 10) - 1] == slow2[(polocz2 / 10) - 1] && p.NazwaSlowa[(polocz4 % 10) - 1] == slow4[(polocz4 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                            }
                            else // 2, 4 i 5
                            {
                                slow = lista.Where(p => p.NazwaSlowa[(polocz2 % 10) - 1] == slow2[(polocz2 / 10) - 1] && p.NazwaSlowa[(polocz4 % 10) - 1] == slow4[(polocz4 / 10) - 1] && p.NazwaSlowa[(polocz5 % 10) - 1] == slow5[(polocz5 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                            }
                        }
                    }
                    else // 2 i 3
                    {
                        if (polocz4 == 0)
                        {
                            if(polocz5 == 0)
                            {
                                slow = lista.Where(p => p.NazwaSlowa[(polocz2 % 10) - 1] == slow2[(polocz2 / 10) - 1] && p.NazwaSlowa[(polocz3 % 10) - 1] == slow3[(polocz3 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                            }
                            else //2, 3 i 5
                            {
                                slow = lista.Where(p => p.NazwaSlowa[(polocz2 % 10) - 1] == slow2[(polocz2 / 10) - 1] && p.NazwaSlowa[(polocz3 % 10) - 1] == slow3[(polocz3 / 10) - 1] && p.NazwaSlowa[(polocz5 % 10) - 1] == slow5[(polocz5 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                            }
                        }
                        else //2, 3 i 4
                        {
                            slow = lista.Where(p => p.NazwaSlowa[(polocz2 % 10) - 1] == slow2[(polocz2 / 10) - 1] && p.NazwaSlowa[(polocz3 % 10) - 1] == slow3[(polocz3 / 10) - 1] && p.NazwaSlowa[(polocz4 % 10) - 1] == slow4[(polocz4 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                        }
                    }
                }
            }
            else //1
            {
                if(polocz2 == 0)
                {
                    if(polocz3 == 0)
                    {
                        if(polocz4 == 0)
                        {
                            if(polocz5 == 0)
                            {
                                slow = lista.Where(p => p.NazwaSlowa[(polocz1 % 10) - 1] == slow1[(polocz1 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                            }
                            else //1 i 5
                            {
                                slow = lista.Where(p => p.NazwaSlowa[(polocz1 % 10) - 1] == slow1[(polocz1 / 10) - 1] && p.NazwaSlowa[(polocz5 % 10) - 1] == slow5[(polocz5 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                            }
                        }
                        else //1 i 4
                        {
                            if(polocz5 == 0)
                            {
                                slow = lista.Where(p => p.NazwaSlowa[(polocz1 % 10) - 1] == slow1[(polocz1 / 10) - 1] && p.NazwaSlowa[(polocz4 % 10) - 1] == slow4[(polocz4 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                            }
                            else //1, 4 i 5
                            {
                                slow = lista.Where(p => p.NazwaSlowa[(polocz1 % 10) - 1] == slow1[(polocz1 / 10) - 1] && p.NazwaSlowa[(polocz4 % 10) - 1] == slow4[(polocz4 / 10) - 1] && p.NazwaSlowa[(polocz5 % 10) - 1] == slow5[(polocz5 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                            }
                        }
                    }
                    else //1 i 3
                    {
                        if(polocz4 == 0)
                        {
                            if(polocz5 == 0)
                            {
                                slow = lista.Where(p => p.NazwaSlowa[(polocz1 % 10) - 1] == slow1[(polocz1 / 10) - 1] && p.NazwaSlowa[(polocz3 % 10) - 1] == slow3[(polocz3 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                            }
                            else //1, 3 i 5
                            {
                                slow = lista.Where(p => p.NazwaSlowa[(polocz1 % 10) - 1] == slow1[(polocz1 / 10) - 1] && p.NazwaSlowa[(polocz3 % 10) - 1] == slow3[(polocz3 / 10) - 1] && p.NazwaSlowa[(polocz5 % 10) - 1] == slow5[(polocz5 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                            }
                        }
                        else //1, 3 i 4
                        {
                            slow = lista.Where(p => p.NazwaSlowa[(polocz1 % 10) - 1] == slow1[(polocz1 / 10) - 1] && p.NazwaSlowa[(polocz3 % 10) - 1] == slow3[(polocz3 / 10) - 1] && p.NazwaSlowa[(polocz4 % 10) - 1] == slow4[(polocz4 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                        }
                    }
                }
                else //1 i 2
                {
                    if(polocz3 == 0)
                    {
                        if(polocz4 == 0)
                        {
                            if(polocz5 == 0)
                            {
                                slow = lista.Where(p => p.NazwaSlowa[(polocz1 % 10) - 1] == slow1[(polocz1 / 10) - 1] && p.NazwaSlowa[(polocz2 % 10) - 1] == slow2[(polocz2 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                            }
                            else //1, 2 i 5
                            {
                                slow = lista.Where(p => p.NazwaSlowa[(polocz1 % 10) - 1] == slow1[(polocz1 / 10) - 1] && p.NazwaSlowa[(polocz2 % 10) - 1] == slow2[(polocz2 / 10) - 1] && p.NazwaSlowa[(polocz5 % 10) - 1] == slow5[(polocz5 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                            }
                        }
                        else //1, 2 i 4
                        {
                            slow = lista.Where(p => p.NazwaSlowa[(polocz1 % 10) - 1] == slow1[(polocz1 / 10) - 1] && p.NazwaSlowa[(polocz2 % 10) - 1] == slow2[(polocz2 / 10) - 1] && p.NazwaSlowa[(polocz4 % 10) - 1] == slow4[(polocz4 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                        }
                    }
                    else //1 2 i 3
                    {
                        slow = lista.Where(p => p.NazwaSlowa[(polocz1 % 10) - 1] == slow1[(polocz1 / 10) - 1] && p.NazwaSlowa[(polocz2 % 10) - 1] == slow2[(polocz2 / 10) - 1] && p.NazwaSlowa[(polocz3 % 10) - 1] == slow3[(polocz3 / 10) - 1]).Skip(ziarno).FirstOrDefault();
                    }
                }

            }

            string pomoc = "Nic";
            if (slow != null)
            {
                pomoc = slow.NazwaSlowa;
            }
            return pomoc;
        }

        public ICollection<Slowo> GetSlowoDlugosc(int dlugosc)
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
