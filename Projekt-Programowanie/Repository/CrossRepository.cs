using Projekt_Programowanie.Data;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Repository
{
    public class CrossRepository : ICrossRepository
    {
        private readonly DataContext _context;
        public CrossRepository(DataContext context)
        {
            _context = context;
        }

        /*public ICollection<Wzor> getWzory()
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

        public int generowanie(int wzor)
        {
            Wzor jaki = getWzor(wzor);
            int slowo1 = jaki.Slowo1;
            int slowo2 = jaki.Slowo2;
            int slowo3 = jaki.Slowo3;
            int slowo4 = jaki.Slowo5;
            int slowo5 = jaki.Slowo5;
            int slowo6 = jaki.Slowo6;

            int[,] tab = new int[8, 8];
            
            return 0;
        }*/
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
