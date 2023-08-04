using Projekt_Programowanie.Models.MODELS;

namespace Projekt_Programowanie.Interfaces
{
    public interface ITableRepository
    {
        ICollection<TabelaWynikow> getTabela();
    }
}
