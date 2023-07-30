using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Interfaces
{
    public interface IQuestionRepository
    {
        ICollection<Pytanie> getPytania();
    }
}
