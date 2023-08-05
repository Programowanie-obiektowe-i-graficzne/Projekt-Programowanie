using Projekt_Programowanie.Data;
using Projekt_Programowanie.Interfaces;
using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DataContext _context;
        public QuestionRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Pytanie> getPytania()
        {
            return _context.Pytania.OrderBy(p => p.ID_Pytania).ToList();
        }

        public Pytanie GetPytanie(int id)
        {
            return _context.Pytania.Where(p => p.ID_Pytania == id).FirstOrDefault();
        }
        public Pytanie GetPytanie(string pytanie)
        {
            return _context.Pytania.Where(p => p.Tresc == pytanie).FirstOrDefault();
        }

        public ICollection<Pytanie> GetPytaniaTrudnosc(int trudnosc)
        {
            return _context.Pytania.Where(p => p.Trudnosc == trudnosc).ToList();
        }

        public ICollection<Pytanie> GetPytaniaOdpowiedz(Slowo odpowiedz)
        {
            return _context.Pytania.Where(p => p.Odpowiedz == odpowiedz).ToList();
        }
    }
}
