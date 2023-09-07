using Projekt_Programowanie.Data;
using Projekt_Programowanie.Interfaces;
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

        public ICollection<Wzor> getWzory()
        {
            throw new NotImplementedException();
        }

        ICollection<Wzor> GetWzory()
        {
            return _context.Wzory.OrderBy(p => p.ID_Wzoru).ToList();
        }

        public Wzor getWzor(int id)
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
            x-= (wsp_y(dane)*10);
            x /= 1000;
            return x;
        }

        public int kierunek(int dane)
        {
            int kier = dane;
            kier -= dlugosc(dane);
            kier -= (wsp_x(dane) * 1000);
            kier-= (wsp_y(dane) * 10);
            kier /= 100000;
            return kier;
        }

        public char[,] wprowadz(int dane, char[,] tabelka)
        {
            char[,] pomoc = tabelka;
            int dlug = dlugosc(dane);
            int wspX = wsp_x(dane);
            int wspY = wsp_y(dane);
            int kieru = kierunek(dane);
            for (int i = 0; i < dlug; i++)
            {
                if (pomoc[wspX,wspY] == '.')
                {
                    pomoc[wspX, wspY] = ',';
                }
                else
                {
                    pomoc[wspX, wspY] = '.';
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
        public char[,] wprowadz(int dane, char[,] tabelka, string slowo)
        {
            char[,] pomoc = tabelka;
            int dlug = dlugosc(dane);
            int wspX = wsp_x(dane);
            int wspY = wsp_y(dane);
            int kieru = kierunek(dane);
            int pom = 0;
            for (int i = 0; i < dlug; i++)
            {
                pomoc[wspX, wspY] = slowo[pom];
                pom += 1;
                if (kieru == 1)
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
                pomoc -= dl2;
                pomoc += 10;
            }

            return polaczenie;
        }

        public char[,] generowanie(int wzor)
        {
            Wzor jaki = getWzor(wzor);
            int rozmiar = jaki.Rozmiar;
            int slowo1 = jaki.Slowo1;
            int slowo2 = jaki.Slowo2;
            int slowo3 = jaki.Slowo3;
            int slowo4 = jaki.Slowo5;
            int slowo5 = jaki.Slowo5;
            int slowo6 = jaki.Slowo6;

            char[,] tab = new char[rozmiar, rozmiar];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j< 8; j++)
                {
                    tab[i, j] = '?';
                }
            }

           /* tab = wprowadz(slowo1, tab);
            tab = wprowadz(slowo2, tab);
            tab = wprowadz(slowo3, tab);
            tab = wprowadz(slowo4, tab);
            tab = wprowadz(slowo5, tab);
            tab = wprowadz(slowo6, tab); */

            ICollection<Slowo> list1 = GetSlowoDlugosc(dlugosc(slowo1));
            ICollection<Slowo> list2 = GetSlowoDlugosc(dlugosc(slowo2));
            ICollection<Slowo> list3 = GetSlowoDlugosc(dlugosc(slowo3));
            ICollection<Slowo> list4 = GetSlowoDlugosc(dlugosc(slowo4));
            ICollection<Slowo> list5 = GetSlowoDlugosc(dlugosc(slowo5));
            ICollection<Slowo> list6 = GetSlowoDlugosc(dlugosc(slowo6));

            Random ran = new Random(); 
            int r1 = ran.Next();
            int r2 = ran.Next();
            int r3 = ran.Next();
            string ss1 = "aaaaaa", ss2 = "aaaaaa", ss3 = "aaaaaa", ss4 = "aaaaaa", ss5 = "aaaaaa", ss6 = "aaaaaa";
            bool czy = false;
            for (int i = 0; i< list1.Count(); i++) //szukanie slowa 1
            {
                ss1 = znajdzSlowo(list1, 0, 0, 0, 0, 0, "", "", "", "", "", (r1 + i) % list1.Count());
                if (ss1 == "Nic")
                    continue;
                for (int j = 0; j < list2.Count(); j++) //szukanie slowa 2
                {
                    ss2 = znajdzSlowo(list2, znajdzPolaczenie(slowo1, slowo2), 0, 0, 0, 0, ss1, "", "", "", "", (r2 + j) % list2.Count());
                    if (ss2 == "Nic")
                        continue;
                    for(int q = 0; q < list3.Count(); q++) //szukanie slowa 3
                    {
                       ss3 = znajdzSlowo(list3, znajdzPolaczenie(slowo1, slowo3), znajdzPolaczenie(slowo2, slowo3), 0, 0, 0, ss1, ss2, "", "", "", (r3 + q) % list3.Count());
                        if (ss3 == "Nic")
                            continue;
                        for (int w = 0; w < list4.Count(); w++) //szukanie slowa 4
                        {
                            ss4 = znajdzSlowo(list4, znajdzPolaczenie(slowo1, slowo4), znajdzPolaczenie(slowo2, slowo4), znajdzPolaczenie(slowo3, slowo4), 0, 0, ss1, ss2, ss3, "", "", (r1 + w) % list4.Count());
                            if (ss4 == "Nic")
                                continue;
                            for (int e = 0; e < list5.Count(); e++) //szukanie slowa 5
                            {
                                ss5 = znajdzSlowo(list5, znajdzPolaczenie(slowo1, slowo5), znajdzPolaczenie(slowo2, slowo5), znajdzPolaczenie(slowo3, slowo5), znajdzPolaczenie(slowo4, slowo5), 0, ss1, ss2, ss3, ss4, "", (r2 + e) % list5.Count());
                                if (ss5 == "Nic")
                                    continue;
                                for (int r = 0; r < list6.Count(); r++) //szukanie slowa 6
                                {
                                    ss6 = znajdzSlowo(list6, znajdzPolaczenie(slowo1, slowo6), znajdzPolaczenie(slowo2, slowo6), znajdzPolaczenie(slowo3, slowo6), znajdzPolaczenie(slowo4, slowo6), znajdzPolaczenie(slowo5, slowo6), ss1, ss2, ss3, ss4, ss5, (r3 + r) % list6.Count());
                                    if (ss6 == "Nic")
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

            tab = wprowadz(slowo1, tab, ss1);
            tab = wprowadz(slowo2, tab, ss2);
            tab = wprowadz(slowo3, tab, ss3);
            tab = wprowadz(slowo4, tab, ss4);
            tab = wprowadz(slowo5, tab, ss5);
            tab = wprowadz(slowo6, tab, ss6);

            return tab;
        }

        public String znajdzSlowo(ICollection<Slowo> lista, int polocz1, int polocz2, int polocz3, int polocz4, int polocz5, String slow1, String slow2, String slow3, String slow4, String slow5, int ziarno)
        {
            String wyraz;
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

        public ICollection<Krzyzowka> getKrzyzowki()
        {
            return _context.Krzyzowki.OrderBy(p => p.ID_Krzyzowki).ToList();
        }
        public Krzyzowka GetKrzyzowka(int id)
        {
            return _context.Krzyzowki.Where(p => p.ID_Krzyzowki == id).FirstOrDefault();
        }
        public bool KrzyzowkaExist(int id)
        {
            return _context.Krzyzowki.Any(p => p.ID_Krzyzowki == id);
        }
        public ICollection<Krzyzowka> GetKrzyzowkiTrudnosc(int trudnosc)
        {
            return _context.Krzyzowki.Where(p => p.Trudnosc==trudnosc).ToList();
        }
        public ICollection<Krzyzowka> GetKrzyzowkiWzor(Wzor wzor)
        {
            return _context.Krzyzowki.Where(p => p.Wzor == wzor).ToList();
        }
    }
}
