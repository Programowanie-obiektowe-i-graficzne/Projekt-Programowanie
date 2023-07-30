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

        public ICollection<Pytanie> GetPytania()
        {
            return _context.Pytania.OrderBy(p => p.ID_Pytania).ToList();
        }

        public ICollection<Pytanie> getPytania()
        {
            throw new NotImplementedException();
        }
    }
}
